using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public partial class JsonDataManager
{
    private Dictionary<int, string> _stringKRDict = new();

    public async UniTask LoadString()
    {
        _stringKRDict = GetStringKRScriptList.ToDictionary(_1 => _1.stringID, _2 => _2.stringData);
        await UniTask.CompletedTask;
    }

    public string GetStringData(int stringID)
    {
        if (_stringKRDict.TryGetValue(stringID, out var ret) == false)
            return "";

        return ret;
    }
}
