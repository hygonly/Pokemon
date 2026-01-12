using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson
{
    public partial class JsonFormatter
    {
        public const string JsonFormat =
@"[
    {0}
]";

        public const string JsonDataFormat =
@"  {{
        {0}
    }},";

        public const string JsonFieldFormat = "\t\"{0}\": {1}\n";
        public string FieldFormat = "public {0} {1};\n";
        public string LoadFormat = "Load{0}Script()\n";
        public string ClearFormat = "Clear{0}Script();\n";

        public string GetJson(JsonInfo fieldInfo)
        {
            string result = "";
            foreach (var item in fieldInfo.infos)
            {
                result += GetJsonData(item.Value);
            }

            return string.Format(JsonDataFormat, result);
        }

        private string GetJsonData(List<JsonFieldInfo> infos)
        {
            string ret = string.Empty;
            foreach (var info in infos)
                ret += string.Format(JsonFieldFormat, info.name, info.value);

            return ret;
        }
    }
}
