using Cysharp.Threading.Tasks;
using UnityEngine;

public partial class JsonDataManager : SlaveManager
{
    public async void InitParser()
    {
        await UniTask.WhenAll(
                LoadString(),
                LoadSkill(),
                LoadPokemon()
            );
    }
}
