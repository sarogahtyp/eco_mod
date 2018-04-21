using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Players;
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
    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class MiningPickupAmountSkill : Skill
    {
        public override string FriendlyName { get { return "Mining Pickup amount"; } }
        public override string Description { get { return "Pickup near rubble when right-click rubble with pickaxe. Levels increase max amount."; } }

        public static int[] SkillPointCost = { 5, 7, 10, 15, 20 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 5; } }
    }

    [Serialized]
    [RequiresSkill(typeof(MiningPickupAmountSkill), 1)]
    public partial class MiningPickupRangeSkill : Skill
    {
        public override string FriendlyName { get { return "Mining Pickup range"; } }
        public override string Description { get { return "Increase the range of the mining pickup."; } }

        public static int[] SkillPointCost = { 5, 7, 10, 15, 20 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 5; } }
    }

    [Serialized]
    [RequiresSkill(typeof(MiningSkill), 1)]
    public partial class StrongMiningSkill : Skill
    {
        public override string FriendlyName { get { return "Strong Mining"; } }
        public override string Description { get { return "Have chance to break directly big rubble when mine blocks. (20% chance per level)"; } }

        public static int[] SkillPointCost = { 5, 10, 15, 30, 50 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 5; } }
    }
}
