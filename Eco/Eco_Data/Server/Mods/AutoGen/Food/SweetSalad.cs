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
    [Weight(400)]                                          
    public partial class SweetSaladItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Sweet Salad"; } }
        public override string Description                      { get { return "The sweetness of the fruits happens to work well with the salad."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 9, Protein = 7, Vitamins = 18};
        public override float Calories                          { get { return 1100; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]    
    public partial class SweetSaladRecipe : Recipe
    {
        public SweetSaladRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SweetSaladItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BasicSaladItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FruitSaladItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SimpleSyrupItem>(typeof(CulinaryArtsEfficiencySkill), 10, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SweetSaladRecipe), Item.Get<SweetSaladItem>().UILink(), 15, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Sweet Salad", typeof(SweetSaladRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}