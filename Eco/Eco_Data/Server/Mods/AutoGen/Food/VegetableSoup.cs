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
    [Weight(900)]                                          
    public partial class VegetableSoupItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Vegetable Soup"; } }
        public override string Description                      { get { return "Who knew plants in plant broth could be so tasty?"; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 3, Protein = 3, Vitamins = 12};
        public override float Calories                          { get { return 1200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 3)]    
    public partial class VegetableSoupRecipe : Recipe
    {
        public VegetableSoupRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<VegetableSoupItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<VegetableStockItem>(typeof(HomeCookingEfficiencySkill), 2, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<VegetableMedleyItem>(typeof(HomeCookingEfficiencySkill), 2, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(VegetableSoupRecipe), Item.Get<VegetableSoupItem>().UILink(), 10, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Vegetable Soup", typeof(VegetableSoupRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}