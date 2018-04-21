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
    [RequiresSkill(typeof(ChemistSkill), 0)]    
    public partial class AlchemistrySkill : Skill
    {
        public override string FriendlyName { get { return "Alchemistry"; } }
        public override string Description { get { return Localizer.Do(""); } }
		
		private static List<Tuple<Type, int>> ItemsGiven = new List<Tuple<Type, int>>
        {
            new Tuple<Type, int>(typeof(DistilleryItem), 1),
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
            new MultiplicativeStrategy(new float[] { 1, 1 - 0.2f, 1- 0.35f });
        public static ModificationStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 0, 0.2f, 0.35f });
        public static int[] SkillPointCost = { 1, 5, 10 };
        public override int RequiredPoint { get { return this.Level < this.MaxLevel ? SkillPointCost[this.Level] : 0; } }
        public override int PrevRequiredPoint { get { return this.Level - 1 >= 0 && this.Level - 1 < this.MaxLevel ? SkillPointCost[this.Level - 1] : 0; } }
        public override int MaxLevel { get { return 1; } }
    }
	
[Serialized]
    public partial class AlchemistrySkillBook : SkillBook<AlchemistrySkill, AlchemistrySkillScroll>
    {
        public override string FriendlyName { get { return "Alchemistry Skill Book"; } }
    }

    [Serialized]
    public partial class AlchemistrySkillScroll : SkillScroll<AlchemistrySkill, AlchemistrySkillBook>
    {
        public override string FriendlyName { get { return "Alchemistry Skill Scroll"; } }
    }

    [RequiresSkill(typeof(PrimitivChemistrySkill), 0)] 
    public partial class AlchemistrySkillBookRecipe : Recipe
    {
        public AlchemistrySkillBookRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AlchemistrySkillBook>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BrickItem>(typeof(ResearchEfficiencySkill), 50, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LumberItem>(typeof(ResearchEfficiencySkill), 25, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BottledWaterItem>(typeof(ResearchEfficiencySkill), 15, ResearchEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SugarItem>(typeof(ResearchEfficiencySkill), 15, ResearchEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = new ConstantValue(30);

            this.Initialize("Alchemistry Skill Book", typeof(AlchemistrySkillBookRecipe));
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }
    }
}

