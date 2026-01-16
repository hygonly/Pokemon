using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public partial class JsonDataManager
{
    private Dictionary<long, List<SkillArgInfoScript>> _skillArgScriptDict = new();

    public async UniTask LoadSkill()
    {
        foreach (var item in GetSkillArgInfoScriptList)
        {
            if (_skillArgScriptDict.TryGetValue(item.skillID, out var value) == false)
                _skillArgScriptDict[item.skillID] = new List<SkillArgInfoScript>();

            _skillArgScriptDict[item.skillID].Add(item);
        }
        
        await UniTask.CompletedTask;
    }

    public List<SkillArgInfoScript> GetSkillArgScripts(long skillID)
    {
        if (_skillArgScriptDict.TryGetValue(skillID, out var ret) == false)
            return new List<SkillArgInfoScript>();
        
        return _skillArgScriptDict[skillID];
    }
}