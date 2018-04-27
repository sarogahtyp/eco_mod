namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [MaxStackSize(500)]
    [Weight(100)]                                          
    public partial class LiquidNitrogenItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Liquid Nitrogen"; } }
        public override string Description                      { get { return "Useful for a quick chilling."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 10; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MolecularGastronomySkill), 2)]    
    public partial class LiquidNitrogenRecipe : Recipe
    {
        public LiquidNitrogenRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<LiquidNitrogenItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(MolecularGastronomyEfficiencySkill), 2, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<NitrateItem>(typeof(MolecularGastronomyEfficiencySkill), 5, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(MolecularGastronomyEfficiencySkill), 5, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(LiquidNitrogenRecipe), Item.Get<LiquidNitrogenItem>().UILink(), 20, typeof(MolecularGastronomySpeedSkill)); 
            this.Initialize("Liquid Nitrogen", typeof(LiquidNitrogenRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}