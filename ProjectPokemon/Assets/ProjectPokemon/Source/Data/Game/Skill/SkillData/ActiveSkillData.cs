using Common.Skill.Data;
using UnityEngine;

namespace Common.Skill.Data
{
    public class ActiveSkillData : BaseSkillData
    {
        public Defines.MoveType MoveType { get; set; }
        public int PowerPoint { get; set; }
        public int Accuracy { get; set; }       //명중률
        public int Priority { get; set; }       //우선순위
        public bool Contact { get; set; }       //접촉기인지
        
        public new class Builder : Builder<ActiveSkillData>
        {
            public Builder<ActiveSkillData> SetActiveSkillData(ActiveSkillInfoScript script)
            {
                mSkillData.SkillID = script.skillID;
                mSkillData.Name = Managers.JsonData.GetStringData(script.skillName);
                mSkillData.Description = Managers.JsonData.GetStringData(script.skillDesc);
                
                mSkillData.PowerPoint = script.defaultPowerPoint;
                mSkillData.Accuracy = script.accuracy;
                mSkillData.MoveType = script.skillType;
                mSkillData.Priority = script.skillPriority;
                mSkillData.Contact = script.contact;
                return this; 
            }

            public Builder<ActiveSkillData> AddPowerPoint(int add)
            {
                mSkillData.PowerPoint += add;
                return this;
            }
        }
    }
}
