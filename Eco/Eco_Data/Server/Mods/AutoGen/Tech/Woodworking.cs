namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;

    [Serialized]
    [RequiresSkill(typeof(HewingSkill), 1)]    
    public partial class WoodworkingSkill : Skill
    {
        public override string FriendlyName { get { return "Woodworking"; } }
        public override string Description { get { return Localizer.Do(""); } }
		
		private static List<Tuple<Type, int>> ItemsGiven = new List<Tuple<Type, int>>
        {
            new Tuple<Type, int>(typeof(CarpentryTableItem), 1),
        };

        public override IEnumerable<Type> ItemTypesGiven { get { return ItemsGiven.Select(tuple => tuple.Item1); } }

        [Serialized] private bool HasGivenItems { get; set; }

        public override IAtomicAction CreateLevelUpAction(Player player)
        {
            if (this.Level != 0 || this.HasGivenItems)
                return base.CreateLevelUpAction(player);
            
            InventoryChangeSet changeSet = InventoryChangeSet.New(player.User.Inventory, player.User);
            foreach (Tuple<Type, int> tuple in ItemsGiven)
                changeSet.AddItems(tuple.Item1, tuple.Item2);

            SimpleAtomicAction setHasGivenItems = new SimpleAtomicAction(() => this.HasGivenItems = true);

            return new DecoratedResultAtomicAction(new MultiAtomicAction(changeSet, setHasGivenItems), (result) =>
            {
                if (result.Success) return result;
                else return Skill.CantCarry(ItemDescriptions());
            });
        }
		private static LocString ItemDescriptions()
        {
            return ItemsGiven.Select(x => new LocString(x.Item2 + " " + Item.Get(x.Item1).UILink())).InlineFoldoutListLoc("item");
        }
		[Tooltip(151)] public string GivesItemTooltip { get { return "Grants " + ItemDescriptions(); } }
        public static ModificationStrategy MultiplicativeStrategy = 
            new MultiplicativeStrategy(new float[] { 1, 1 - 0.2f, 1 - 0.35f, 1 - 0.5f, 1 - 0.65f, 1 - 0.8f });
        public static ModificationStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 0, 0.2f, 0.35f, 0.5f, 0.65f, 0.8f });
        public static int[] SkillPointCost = { 1, 1, 2, 2, 3 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 4; } }
    }

}
