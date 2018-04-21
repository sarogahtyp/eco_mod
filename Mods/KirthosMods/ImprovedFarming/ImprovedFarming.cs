using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirthos.Mods
{
    [Serialized]
    [RequiresSkill(typeof(ScytheEfficiencySkill), 4)]
    public partial class FarmingRadiusSkill : Skill
    {
        public override string FriendlyName { get { return "Farming Radius"; } }
        public override string Description { get { return "lvl 0 = 1x1 yield, 1 2x2 yield....,"; } }

        public static int[] SkillPointCost = { 10, 15, 20, 25, 30};
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 5; } }
    }
  
}
