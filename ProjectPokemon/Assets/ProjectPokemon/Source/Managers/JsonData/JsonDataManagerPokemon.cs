using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class JsonDataManager
{
    private Dictionary<long, PokemonInfoScript> _pokemonInfoScriptDict = new();


    public async UniTask LoadPokemon()
    {
        _pokemonInfoScriptDict = GetPokemonInfoScriptList.ToDictionary(_1 => _1.pokemonID, _2 => _2);
        
        await UniTask.CompletedTask;
    }

    public PokemonInfoScript GetPokemonInfo(long pokemonID)
    {
        return _pokemonInfoScriptDict.GetValueOrDefault(pokemonID);
    }

    
}
