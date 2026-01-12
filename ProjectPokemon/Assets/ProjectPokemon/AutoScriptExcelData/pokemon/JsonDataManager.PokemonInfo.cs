/********************************************************/
/*Auto Create File*/
/*Source: ExcelToJson*/
/********************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;

[System.Serializable]
public class PokemonInfoScript
{
	public Int64 pokemonID;
	public Defines.PokemonType firstType;
	public Defines.PokemonType secondType;
	public int name;
	public int index;

}

public partial class JsonDataManager
{
    private List<PokemonInfoScript> GetPokemonInfoScriptList { get { return listPokemonInfoScript; } }
    private List<PokemonInfoScript> listPokemonInfoScript;

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
        listPokemonInfoScript.Clear();
    }
}