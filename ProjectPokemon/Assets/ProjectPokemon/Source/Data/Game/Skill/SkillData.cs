using UnityEngine;

namespace Commmon.Skill.Data
{
    public class SkillData
    {
        public long SkillID { get; set; }
        public int SkillName { get; set; }
        public int SkillDescription { get; set; }

        public bool IsValild() => SkillID != 0;

        public class Builder
        {
            private SkillData _data = new SkillData();

            public Builder SetSkillID(long skillID)
            {
                _data.SkillID = skillID;
                return this;
            }

            public SkillData Build() => _data;
        }
    }
}
