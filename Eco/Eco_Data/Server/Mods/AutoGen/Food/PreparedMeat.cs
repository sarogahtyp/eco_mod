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
    public partial class PreparedMeatItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Prepared Meat"; } }
        public override string Description                      { get { return "Carefully butchered meat, ready to cook."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 6, Protein = 4, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 1)]    
    public partial class PreparedMeatRecipe : Recipe
    {
        public PreparedMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PreparedMeatItem>(),
               
               new CraftingElement<ScrapMeatItem>(2), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MeatPrepEfficiencySkill), 10, MeatPrepEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PreparedMeatRecipe), Item.Get<PreparedMeatItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Prepared Meat", typeof(PreparedMeatRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}