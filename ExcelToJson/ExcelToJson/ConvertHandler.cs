using ExcelDataReader;
using ExcelToJson.Manager;
using ExcelToJson.Utills;
using System.Data;

namespace ExcelToJson
{
    public record struct SourceFieldInfo(string name, string type);
    public record struct JsonFieldInfo(string name, string value);

    public class ConvertHandler
    {
        public static void BuildExcelToJson_Client()
        {
            string excelPath = Managers.InI.GetValue(Defines.InIKeyType.ExcelPath);
            if (string.IsNullOrEmpty(excelPath) == true)
                return;

            DirectoryInfo directory = new DirectoryInfo(excelPath);
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var tables = reader.AsDataSet().Tables;
                    var fieldRow = tables[0].Rows;
                    var sourceFieldInfos = ConvertSourceFieldInfo(fieldRow);
                    for (int tableIndex = 0; tableIndex < tables.Count; tableIndex++)
                    {
                        var jsonFieldInfos = ConvertJsonFieldInfo(fieldRow, sourceFieldInfos);
                        var table = tables[tableIndex];
                        for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                        {
                            var row = table.Rows[rowIndex];
                            for (int columnIndex = 0; columnIndex < row.ItemArray.Length; columnIndex++)
                            {

                            }
                        }
                    }


                    reader.Dispose();
                    reader.Close();
                }
            }
        }

        public static void BuildExcelToSource_Client()
        {

        }

        private static List<SourceFieldInfo> ConvertSourceFieldInfo(DataRowCollection collection)
        {
            List<SourceFieldInfo> result = new List<SourceFieldInfo>();
            for (int i = 0; i < collection.Count; i++)
            {
                SourceFieldInfo info = new SourceFieldInfo();
                string field = collection[i].ToString();
                int index = field.LastIndexOf(".") - 1;
                if (index > 0)
                {
                    info.type = field.Substring(0, index);
                }
                else
                {
                    index = 0;
                    info.type = "int";
                }

                info.name = field.Substring(index);
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