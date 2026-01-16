using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public partial class UserInfoManager : SlaveManager
{
    private LoginUserData _userData;

    public async UniTask Init()
    {
        _userData = CreateUserData();

        await UniTask.CompletedTask;
    }

    public LoginUserData CreateUserData()
    {
        LoginUserData userData = new LoginUserData();
        userData.UserUID = 1;
        userData.UserName = "Test1";
        userData.PokemonDatas = new List<UserPokemonData>();
        return userData;
    }

    public UserPokemonData CreateUserPokemonData()
    {
        UserPokemonData data = new UserPokemonData();
        data.PokemonID = 1;
        data.Level = 1;
        data.NatureType = Defines.NatureType.Modest;
        data.LearnedSkillDatas = new List<PokemonSkillData>();
        data.SkillDatas = new List<PokemonSkillData>();


        return data;
    }
}
