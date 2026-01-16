using Common.Skill.Effect.Data;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace Common.Skill.Data
{
    public class SkillData
    {
        public long SkillID { get; set; }
        public Defines.SkillType SkillType { get; set; }
        
        public class Builder
        {
            private SkillData mSkillData = new SkillData();

            public Builder SetSkillID(long skillID)
            {
                mSkillData.SkillID = skillID;
                return this;
            }

            public Builder SetSkillType(Defines.SkillType skillType)
            {
                mSkillData.SkillType = skillType;
                return this;
            }

            public SkillData Build() => mSkillData;
        }
    }

    public class BaseSkillData : SkillData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<EffectData> EffectDatas { get; set; } = new List<EffectData>();
    
        public class Builder<T> where T : BaseSkillData, new()
        {
            protected T mSkillData = new T();

            public T Build() => mSkillData;

            //@TODO EffectData 생성 부분 여기다가 만들어서 Skill 만들 때 EffectData도 같이 만들도록 설계하기
        
            //public List<EffectData> CreateEffectData
        }
    }
}
