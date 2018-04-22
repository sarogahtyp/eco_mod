using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirthos.Mods
{
    class SkillsUtil
    {
        public static bool HasSkillLevel(User user, Type skillType, int level)
        {
            foreach(Skill skill in user.Skillset.Skills)
            {
                if (skill.Type == skillType)
                {
                    if (skill.Level >= level)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int GetSkillLevel(User user, Type skillType)
        {
            foreach (Skill skill in user.Skillset.Skills)
            {
                if (skill.Type == skillType)
                {
                    return skill.Level;
                }
            }
            return 0;
        }
    }
}
