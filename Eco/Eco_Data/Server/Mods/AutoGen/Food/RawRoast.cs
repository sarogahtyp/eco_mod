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
    [Weight(500)]                                          
    public partial class RawRoastItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Raw Roast"; } }
        public override string Description                      { get { return "A trussed roast tied and ready to be cooked."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 5, Protein = 6, Vitamins = 0};
        public override float Calories                          { get { return 800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 2)]    
    public partial class RawRoastRecipe : Recipe
    {
        public RawRoastRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawRoastItem>(),
               
               new CraftingElement<ScrapMeatItem>(3), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MeatPrepEfficiencySkill), 20, MeatPrepEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RawRoastRecipe), Item.Get<RawRoastItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Raw Roast", typeof(RawRoastRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}