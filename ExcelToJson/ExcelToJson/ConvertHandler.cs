using ExcelDataReader;
using ExcelToJson.Manager;
using ExcelToJson.Utills;
using System.Data;

namespace ExcelToJson
{
    public record struct SourceFieldInfo(string name, string type);
    public record struct JsonFieldInfo(string name, string value);
    public record struct JsonInfo(string directory, string fileName, List<JsonFieldInfo> infos);

    public class ConvertHandler
    {
        public static void BuildExcelDataToClient()
        {
            string excelPath = Managers.InI.GetValue(Defines.InIKeyType.ExcelPath);
            if (string.IsNullOrEmpty(excelPath) == true)
                return;

            JsonDataManagerFormatter.Builder builder = new JsonDataManagerFormatter.Builder();
            DirectoryInfo directory = new DirectoryInfo(excelPath);
            var classNames = new List<string>();
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var tables = reader.AsDataSet().Tables;
                    var rows = tables[0].Rows;
                    JsonInfo json = new JsonInfo();

                    //public string name 같은 소스 변수
                    for (int tableIndex = 0; tableIndex < tables.Count; tableIndex++)
                    {
                        //엑셀 데이터를 json 형식으로 변환
                        var table = tables[tableIndex];
                        var sourceFieldInfos = ConvertSourceFieldInfo(rows);
                        var jsonFieldInfos = ConvertJsonFieldInfo(rows, sourceFieldInfos);

                        string tableName = table.TableName;
                        string directoryName = StringHelper.GetDirectoryName(tableName);
                        string fileName = StringHelper.GetFileName(tableName);
                        
                        json.infos = new List<JsonFieldInfo>();
                        json.directory = directoryName;
                        json.fileName = fileName;

                        classNames.Add(StringHelper.GetClassName(tableName));
                        builder.CreateJsonDataManager(sourceFieldInfos, directoryName, fileName);
                        builder.CreateJson(json, directoryName, fileName);
                    }
                    
                    reader.Dispose();
                    reader.Close();
                }
            }

            builder.CreateJsonDataManagerLoader(classNames);
        }

        private static List<SourceFieldInfo> ConvertSourceFieldInfo(DataRowCollection collection)
        {
            List<SourceFieldInfo> result = new List<SourceFieldInfo>();
            for (int i = 0; i < collection.Count; i++)
            {
                SourceFieldInfo info = new SourceFieldInfo();
                string field = collection[i].ToString();

                info.type = StringHelper.GetFieldType(field);
                info.name = StringHelper.GetVariableName(field);
                result.Add(info);
            }

            return result;
        }

        private static List<JsonFieldInfo> ConvertJsonFieldInfo(DataRowCollection collection, List<SourceFieldInfo> fieldInfos)
        {
            List<JsonFieldInfo> result = new List<JsonFieldInfo>();
            for (int i = 0; i < collection.Count; i++)
            {
                JsonFieldInfo jsonFieldInfo = new JsonFieldInfo();
                jsonFieldInfo.name = fieldInfos[i].name;
                jsonFieldInfo.value = collection[i].ToString();
                result.Add(jsonFieldInfo);
            }

            return result;
        }
    }
}