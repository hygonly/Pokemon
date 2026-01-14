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
public class SkillArgInfoScript
{
	public Int64 skillID { get; set; }
	public Defines.SkillArgType argType { get; set; }
	public int value { get; set; }
	public Defines.TargetType targetType { get; set; }

}

public partial class JsonDataManager
{
    private List<SkillArgInfoScript> GetSkillArgInfoScriptList { get { return listSkillArgInfoScript; } }
    private List<SkillArgInfoScript> listSkillArgInfoScript;

    [Serializable]
    public class SkillArgInfoScriptAll
    {
        public List<SkillArgInfoScript> result;
    }

    public async UniTask LoadSkillArgInfoScript()
    {
        var resultScript = new List<SkillArgInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("skill", "skillArgInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load skillArgInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<SkillArgInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: skillArgInfo.json Script\n {e.Message}");
        }
        
        listSkillArgInfoScript = resultScript;
        Complete();
    }

    public void ClearSkillArgInfoScript()
    {
        listSkillArgInfoScript?.Clear();
    }
}