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
    public partial class CamasBreadItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Camas Bread"; } }
        public override string FriendlyNamePlural               { get { return "Camas Bread"; } } 
        public override string Description                      { get { return "A bread with a camas twist for a bit of flavor and fun. "; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 16, Fat = 11, Protein = 5, Vitamins = 8};
        public override float Calories                          { get { return 800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(LeavenedBakingSkill), 2)]    
    public partial class CamasBreadRecipe : Recipe
    {
        public CamasBreadRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CamasBreadItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(LeavenedBakingEfficiencySkill), 10, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CamasPasteItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<YeastItem>(typeof(LeavenedBakingEfficiencySkill), 3, LeavenedBakingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CamasBreadRecipe), Item.Get<CamasBreadItem>().UILink(), 8, typeof(LeavenedBakingSpeedSkill)); 
            this.Initialize("Camas Bread", typeof(CamasBreadRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}