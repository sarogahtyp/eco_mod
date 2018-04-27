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
    public partial class CornmealItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Cornmeal"; } }
        public override string FriendlyNamePlural               { get { return "Cornmeal"; } } 
        public override string Description                      { get { return "Dried and ground corn; it's like a courser flour."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 9, Fat = 3, Protein = 3, Vitamins = 0};
        public override float Calories                          { get { return 60; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillProcessingSkill), 2)]    
    public partial class CornmealRecipe : Recipe
    {
        public CornmealRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CornmealItem>(),
               
               new CraftingElement<CerealGermItem>(2), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornItem>(typeof(MillProcessingEfficiencySkill), 10, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornmealRecipe), Item.Get<CornmealItem>().UILink(), 5, typeof(MillProcessingSpeedSkill)); 
            this.Initialize("Cornmeal", typeof(CornmealRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}