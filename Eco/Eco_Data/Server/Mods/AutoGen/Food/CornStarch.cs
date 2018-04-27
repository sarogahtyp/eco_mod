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
    public partial class CornStarchItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Corn Starch"; } }
        public override string Description                      { get { return "Obtained from the endosperm of the kernal, cornstarch can be used as a thickening agent for sauces."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 10; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MolecularGastronomySkill), 1)]    
    public partial class CornStarchRecipe : Recipe
    {
        public CornStarchRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CornStarchItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(MolecularGastronomyEfficiencySkill), 10, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MolecularGastronomyEfficiencySkill), 10, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornStarchRecipe), Item.Get<CornStarchItem>().UILink(), 20, typeof(MolecularGastronomySpeedSkill)); 
            this.Initialize("Corn Starch", typeof(CornStarchRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}