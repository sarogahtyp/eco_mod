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
    [Weight(200)]                                          
    public partial class FlatbreadItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Flatbread"; } }
        public override string Description                      { get { return "Without any leavening the flatbread isn't very puffy. But it's still tasty."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 12, Fat = 2, Protein = 6, Vitamins = 0};
        public override float Calories                          { get { return 500; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 1)]    
    public partial class FlatbreadRecipe : Recipe
    {
        public FlatbreadRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FlatbreadItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(BasicBakingEfficiencySkill), 10, BasicBakingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FlatbreadRecipe), Item.Get<FlatbreadItem>().UILink(), 5, typeof(BasicBakingSpeedSkill)); 
            this.Initialize("Flatbread", typeof(FlatbreadRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}