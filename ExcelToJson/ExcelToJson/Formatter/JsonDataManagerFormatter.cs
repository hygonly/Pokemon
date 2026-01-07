using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson
{
    public partial class JsonDataManagerFormatter
    {
        public const string JsonFormat =
@"[
    {0}
]";

        public const string JsonDataFormat =
@"  {{
        {0}
    }},";

        public const string JsonFieldFormat = "\"{0}\": {1}\n";
    }
}
