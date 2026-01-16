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
public class ActiveSkillInfoScript
{
	public Int64 skillID { get; set; }
	public Defines.SkillCategoryType skillCategoryType { get; set; }
	public Defines.MoveType skillType { get; set; }
	public int accuracy { get; set; }
	public int defaultPowerPoint { get; set; }
	public int skillName { get; set; }
	public int skillDesc { get; set; }
	public int skillPriority { get; set; }
	public bool contact { get; set; }

}

public partial class JsonDataManager
{
    private List<ActiveSkillInfoScript> GetActiveSkillInfoScriptList { get { return listActiveSkillInfoScript; } }
    private List<ActiveSkillInfoScript> listActiveSkillInfoScript;

    [Serializable]
    public class ActiveSkillInfoScriptAll
    {
        public List<ActiveSkillInfoScript> result;
    }

    public async UniTask LoadActiveSkillInfoScript()
    {
        var resultScript = new List<ActiveSkillInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("skill", "activeSkillInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load activeSkillInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<ActiveSkillInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: activeSkillInfo.json Script\n {e.Message}");
        }
        
        listActiveSkillInfoScript = resultScript;
        Complete();
    }

    public void ClearActiveSkillInfoScript()
    {
        listActiveSkillInfoScript?.Clear();
    }
}