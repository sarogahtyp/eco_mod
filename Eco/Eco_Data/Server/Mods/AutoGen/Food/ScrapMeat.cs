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
    [Weight(10)]                                          
    public partial class ScrapMeatItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Scrap Meat"; } }
        public override string Description                      { get { return "Chunks of extra meat."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 5, Protein = 5, Vitamins = 0};
        public override float Calories                          { get { return 50; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 1)]    
    public partial class ScrapMeatRecipe : Recipe
    {
        public ScrapMeatRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawMeatItem>(typeof(MeatPrepEfficiencySkill), 1, MeatPrepEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ScrapMeatRecipe), Item.Get<ScrapMeatItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Scrap Meat", typeof(ScrapMeatRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}