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
    [Weight(800)]                                          
    public partial class VegetableStockItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Vegetable Stock"; } }
        public override string Description                      { get { return "A hearty stock full of assorted vegetables."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 0, Protein = 0, Vitamins = 12};
        public override float Calories                          { get { return 700; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]    
    public partial class VegetableStockRecipe : Recipe
    {
        public VegetableStockRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<VegetableStockItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<VegetableMedleyItem>(typeof(HomeCookingEfficiencySkill), 4, HomeCookingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(HomeCookingEfficiencySkill), 1, HomeCookingEfficiencySkill.MultiplicativeStrategy),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(VegetableStockRecipe), Item.Get<VegetableStockItem>().UILink(), 20, typeof(HomeCookingSpeedSkill)); 
            this.Initialize("Vegetable Stock", typeof(VegetableStockRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}