using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToJson
{
    public partial class JsonDataManagerFormatter
    {
        //{0}: Class name
        //{1}: Parent file name
        //{2}: File name
        //{3}: Fields
        public string ClientJsonDataManagerFormat =
@"/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class {0}Script
{{
{3}
}}

public partial class JsonDataManager
{{
    private List<{0}Script> Get{0}ScriptList { get { return list{0}Script; } 
    private List<{0}Script> list{0}Script;

    public class {0}ScriptAll
    {
        public List<{0}Script> result;
    }

    public async UniTask LoadTestScript()
    {{
        var resultScript = new List<{0}Script>();

        try
        {{
            var load = await Managers.Resource.LoadScript(""{1}"", ""{2}"");
            if (string.IsNullOrEmpty(load) == true)
            {{
                Debug.LogError(""Failed load {2} Script"");
                return;
            }}

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<{0}ScriptAll>(""{{ \""result\"" : "" + load + ""}}"", settings);
            resultScript = json.result;
        }}
        catch (Exception e)
        {{
            Debug.LogError($""Load Failed: {2} Script\n {e.Message}"");
        }}
        
        listTestScript = resultScript;
        Complete();
    }}
}}";
        

        //{0}: Clear scripts
        //{1}: Load scripts
        public string ClientJsonDataManagerLoaderFormat =
@"/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using Cysharp.Threading.Tasks;

public partial class JsonDataManager
{{
    public int LoadCount {{ get {{ return _loadCount; }} }}
    public int MaxCount {{ get {{ return _maxCount;  }} }}

    private int _loadCount;
    private int _maxCount;

    public void Complete()
    {{
        _loadCount++;
    }}

    public float GetLoadProgress() {{ return (float)_loadCount / _maxCount; }}

    public async UniTask LoadAll()
    {{
        _loadCount = 0;
{0}

        await UniTask.WhenAll(
{1}
        );
    }}
}}";

        public string FieldFormat = "public {0} {1}";
    }
}
