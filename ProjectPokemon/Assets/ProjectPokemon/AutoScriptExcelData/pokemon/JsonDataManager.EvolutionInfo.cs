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
public class EvolutionInfoScript
{
	public int pokemonID { get; set; }
	public int level { get; set; }
	public int evolutionID { get; set; }

}

public partial class JsonDataManager
{
    private List<EvolutionInfoScript> GetEvolutionInfoScriptList { get { return listEvolutionInfoScript; } }
    private List<EvolutionInfoScript> listEvolutionInfoScript;

    [Serializable]
    public class EvolutionInfoScriptAll
    {
        public List<EvolutionInfoScript> result;
    }

    public async UniTask LoadEvolutionInfoScript()
    {
        var resultScript = new List<EvolutionInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("pokemon", "evolutionInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load evolutionInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<EvolutionInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: evolutionInfo.json Script\n {e.Message}");
        }
        
        listEvolutionInfoScript = resultScript;
        Complete();
    }

    public void ClearEvolutionInfoScript()
    {
        listEvolutionInfoScript?.Clear();
    }
}