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
    public partial class SugarItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Sugar"; } }
        public override string FriendlyNamePlural               { get { return "Sugar"; } } 
        public override string Description                      { get { return "Even sweet lovers don't eat sugar plain."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 15, Fat = 0, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 50; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillProcessingSkill), 1)]    
    public partial class SugarRecipe : Recipe
    {
        public SugarRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SugarItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberriesItem>(typeof(MillProcessingEfficiencySkill), 20, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SugarRecipe), Item.Get<SugarItem>().UILink(), 5, typeof(MillProcessingSpeedSkill)); 
            this.Initialize("Sugar", typeof(SugarRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}