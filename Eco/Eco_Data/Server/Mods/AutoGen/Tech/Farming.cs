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
    [RequiresSkill(typeof(FarmerSkill), 0)]    
    public partial class FarmingSkill : Skill
    {
        public override string FriendlyName { get { return "Farming"; } }
        public override string Description { get { return Localizer.Do(""); } }
		
		private static List<Tuple<Type, int>> ItemsGiven = new List<Tuple<Type, int>>
        {
            new Tuple<Type, int>(typeof(FarmersTableItem), 1),
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

        public static int[] SkillPointCost = { 1, 1, 1, 1, 1 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }

    [Serialized]
    public partial class FarmingSkillBook : SkillBook<FarmingSkill, FarmingSkillScroll>
    {
        public override string FriendlyName { get { return "Farming Skill Book"; } }
    }

    [Serialized]
    public partial class FarmingSkillScroll : SkillScroll<FarmingSkill, FarmingSkillBook>
    {
        public override string FriendlyName { get { return "Farming Skill Scroll"; } }
    }

    [RequiresSkill(typeof(GatheringSkill), 0)] 
    public partial class FarmingSkillBookRecipe : Recipe
    {
        public FarmingSkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FarmingSkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberrySeedItem>(typeof(ResearchEfficiencySkill), 5, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CornSeedItem>(typeof(ResearchEfficiencySkill), 5, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CriminiMushroomSporesItem>(typeof(ResearchEfficiencySkill), 5, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(5);

            this.Initialize("Farming Skill Book", typeof(FarmingSkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}
