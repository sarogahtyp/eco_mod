namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Yield(typeof(PricklyPearSeedItem), typeof(DesertDrifterSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [MaxStackSize(500)]
    [Weight(10)]  
    public partial class PricklyPearSeedItem : SeedItem
    {
        static PricklyPearSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Prickly Pear Seed"; } }
        public override string Description  { get { return "Plant to grow prickly pear cacti."; } }
        public override string SpeciesName  { get { return "PricklyPear"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class PricklyPearSeedPackItem : SeedPackItem
    {
        static PricklyPearSeedPackItem() { }

        public override string FriendlyName { get { return "Prickly Pear Seed Pack"; } }
        public override string Description  { get { return "Plant to grow prickly pear cacti."; } }
        public override string SpeciesName  { get { return "PricklyPear"; } }
    }

    [RequiresSkill(typeof(SeedProductionSkill), 4)]    
    public class PricklyPearSeedRecipe : Recipe
    {
        public PricklyPearSeedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PricklyPearSeedItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PricklyPearFruitItem>(typeof(SeedProductionEfficiencySkill), 2, SeedProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(2, SeedProductionSpeedSkill.MultiplicativeStrategy, typeof(SeedProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(PricklyPearSeedRecipe), Item.Get<PricklyPearSeedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<PricklyPearSeedItem>().UILink(), value);
            this.CraftMinutes = value;

            this.Initialize("Prickly Pear Seed", typeof(PricklyPearSeedRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}