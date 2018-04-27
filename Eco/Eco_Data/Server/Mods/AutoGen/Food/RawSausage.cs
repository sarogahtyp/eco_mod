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
    [Weight(300)]                                          
    public partial class RawSausageItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Raw Sausage"; } }
        public override string Description                      { get { return "Ground meat stuffed into an intestine casing."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 8, Protein = 4, Vitamins = 0};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 3)]    
    public partial class RawSausageRecipe : Recipe
    {
        public RawSausageRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RawSausageItem>(),
               
               new CraftingElement<TallowItem>(1), 
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(typeof(MeatPrepEfficiencySkill), 20, MeatPrepEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RawSausageRecipe), Item.Get<RawSausageItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Raw Sausage", typeof(RawSausageRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}