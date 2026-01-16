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
public class PokemonInfoScript
{
	public Int64 pokemonID { get; set; }
	public Defines.MoveType firstType { get; set; }
	public Defines.MoveType secondType { get; set; }
	public int name { get; set; }

}

public partial class JsonDataManager
{
    private List<PokemonInfoScript> GetPokemonInfoScriptList { get { return listPokemonInfoScript; } }
    private List<PokemonInfoScript> listPokemonInfoScript;

    [Serializable]
    public class PokemonInfoScriptAll
    {
        public List<PokemonInfoScript> result;
    }

    public async UniTask LoadPokemonInfoScript()
    {
        var resultScript = new List<PokemonInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("pokemon", "pokemonInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load pokemonInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<PokemonInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: pokemonInfo.json Script\n {e.Message}");
        }
        
        listPokemonInfoScript = resultScript;
        Complete();
    }

    public void ClearPokemonInfoScript()
    {
        listPokemonInfoScript?.Clear();
    }
}