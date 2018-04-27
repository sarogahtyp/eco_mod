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
    [Weight(600)]                                          
    public partial class HuckleberryPieItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Huckleberry Pie"; } }
        public override string Description                      { get { return "A fantastic combination of flaky crust and scrumptious berries."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 4, Protein = 4, Vitamins = 12};
        public override float Calories                          { get { return 1300; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 4)]    
    public partial class HuckleberryPieRecipe : Recipe
    {
        public HuckleberryPieRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<HuckleberryPieItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(BasicBakingEfficiencySkill), 10, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberriesItem>(typeof(BasicBakingEfficiencySkill), 50, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TallowItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(HuckleberryPieRecipe), Item.Get<HuckleberryPieItem>().UILink(), 5, typeof(BasicBakingSpeedSkill)); 
            this.Initialize("Huckleberry Pie", typeof(HuckleberryPieRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}