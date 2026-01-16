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
public class NatureInfoScript
{
	public Defines.NatureType natureType { get; set; }
	public Defines StatTypeincreamentStatType { get; set; }
	public Defines.StatType decreamentStatType { get; set; }

}

public partial class JsonDataManager
{
    private List<NatureInfoScript> GetNatureInfoScriptList { get { return listNatureInfoScript; } }
    private List<NatureInfoScript> listNatureInfoScript;

    [Serializable]
    public class NatureInfoScriptAll
    {
        public List<NatureInfoScript> result;
    }

    public async UniTask LoadNatureInfoScript()
    {
        var resultScript = new List<NatureInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("pokemon", "natureInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load natureInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<NatureInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: natureInfo.json Script\n {e.Message}");
        }
        
        listNatureInfoScript = resultScript;
        Complete();
    }

    public void ClearNatureInfoScript()
    {
        listNatureInfoScript?.Clear();
    }
}