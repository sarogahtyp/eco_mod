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
    [RequiresSkill(typeof(LoggingSkill), 1)]
    public partial class WoodPulpCleanerSkill : Skill
    {
        public override string FriendlyName { get { return "Wood pulp cleaner"; } }
        public override string Description { get { return "When break a wood pulp, break others wood pulp around. Levels increase range."; } }

        public static int[] SkillPointCost = { 5, 7, 10, 15, 20 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 5; } }
    }
    //*
    [Serialized]
    [RequiresSkill(typeof(WoodPulpCleanerSkill), 1)]
    public partial class StumpCleanerSkill : Skill
    {
        public override string FriendlyName { get { return "Stump cleaner"; } }
        public override string Description { get { return "Break tree stump in one hit."; } }

        public static int[] SkillPointCost = { 25};
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }
    //*/
    [Serialized]
    [RequiresSkill(typeof(LoggingSkill), 1)]
    public partial class ExpertLumbererSkill : Skill
    {
        public override string FriendlyName { get { return "Expert lumberer"; } }
        public override string Description { get { return "Cut the tree trunk, ready to harvest."; } }

        public static int[] SkillPointCost = { 50 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

}
