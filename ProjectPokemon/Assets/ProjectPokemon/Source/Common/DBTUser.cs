using System.Collections.Generic;
using UnityEngine;

public class LoginUserData
{
    public long UserUID { get; set; }
    public string UserName { get; set; }
    public List<UserPokemonData> PokemonDatas { get; set; }
}

public class UserPokemonData
{
    public long PokemonID { get; set; }
    public int Level { get; set; }
    public Defines.NatureType NatureType { get; set; }
    public List<PokemonSkillData> SkillDatas { get; set; }
    public List<PokemonSkillData> LearnedSkillDatas { get; set; }
}

public class PokemonSkillData
{
    public long SkillID { get; set; }
    public int PowerPoint { get; set; }
}