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
    public partial class WildMixItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Wild Mix"; } }
        public override string Description                      { get { return "A dressed salad that, with the added sweetness, its pretty tasty."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 7, Fat = 3, Protein = 5, Vitamins = 16};
        public override float Calories                          { get { return 800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 1)]    
    public partial class WildMixRecipe : Recipe
    {
        public WildMixRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<WildMixItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BasicSaladItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberryExtractItem>(typeof(CulinaryArtsEfficiencySkill), 4, CulinaryArtsEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(WildMixRecipe), Item.Get<WildMixItem>().UILink(), 10, typeof(CulinaryArtsSpeedSkill)); 
            this.Initialize("Wild Mix", typeof(WildMixRecipe));
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }
    }
}