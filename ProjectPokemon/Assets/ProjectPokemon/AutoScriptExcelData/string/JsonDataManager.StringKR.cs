/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

[Serializable]
public class StringKRScript
{
	public int stringID { get; set; }
	public string stringData { get; set; }

}

public partial class JsonDataManager
{
    private List<StringKRScript> GetStringKRScriptList { get { return listStringKRScript; } }
    private List<StringKRScript> listStringKRScript;

    [Serializable]
    public class StringKRScriptAll
    {
        public List<StringKRScript> result;
    }

    public async UniTask LoadStringKRScript()
    {
        var resultScript = new List<StringKRScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("string", "stringKR.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load stringKR.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<StringKRScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: stringKR.json Script\n {e.Message}");
        }
        
        listStringKRScript = resultScript;
        Complete();
    }

    public void ClearStringKRScript()
    {
        listStringKRScript?.Clear();
    }
}