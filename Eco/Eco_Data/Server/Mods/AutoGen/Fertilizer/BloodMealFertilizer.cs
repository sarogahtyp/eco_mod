namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using System.ComponentModel;

    [RequiresSkill(typeof(FertilizerProductionSkill), 1)]  
    public partial class BloodMealFertilizerRecipe : Recipe
    {
        public BloodMealFertilizerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BloodMealFertilizerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PulpFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ScrapMeatItem>(typeof(FertilizerEfficiencySkill), 15, FertilizerEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BloodMealFertilizerRecipe), Item.Get<BloodMealFertilizerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize("Blood Meal Fertilizer", typeof(BloodMealFertilizerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]  
    [Category("Tool")]
    public partial class BloodMealFertilizerItem : FertilizerItem
    {
        public override string FriendlyName { get { return "Blood Meal Fertilizer"; } }
        public override string Description  { get { return ""; } }

        static BloodMealFertilizerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 3));
            nutrients.Add(new NutrientElement("Phosphorus", 0.4f));
            nutrients.Add(new NutrientElement("Potassium", 0.4f));
        }
    }
}