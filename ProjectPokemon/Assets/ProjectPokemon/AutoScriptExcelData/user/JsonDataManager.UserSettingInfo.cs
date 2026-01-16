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
public class UserSettingInfoScript
{
	public Defines.UserSettingType userSettingType { get; set; }
	public long value { get; set; }

}

public partial class JsonDataManager
{
    private List<UserSettingInfoScript> GetUserSettingInfoScriptList { get { return listUserSettingInfoScript; } }
    private List<UserSettingInfoScript> listUserSettingInfoScript;

    [Serializable]
    public class UserSettingInfoScriptAll
    {
        public List<UserSettingInfoScript> result;
    }

    public async UniTask LoadUserSettingInfoScript()
    {
        var resultScript = new List<UserSettingInfoScript>();

        try
        {
            var load = await Managers.Resource.LoadScript("user", "userSettingInfo.json");
            if (string.IsNullOrEmpty(load) == true)
            {
                Debug.LogError("Failed load userSettingInfo.json Script");
                return;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            var json = JsonConvert.DeserializeObject<UserSettingInfoScriptAll>("{ \"result\" : " + load + "}", settings);
            resultScript = json.result;
        }
        catch (Exception e)
        {
            Debug.LogError($"Load Failed: userSettingInfo.json Script\n {e.Message}");
        }
        
        listUserSettingInfoScript = resultScript;
        Complete();
    }

    public void ClearUserSettingInfoScript()
    {
        listUserSettingInfoScript?.Clear();
    }
}