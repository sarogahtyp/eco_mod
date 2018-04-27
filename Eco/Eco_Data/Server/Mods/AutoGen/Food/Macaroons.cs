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
    public partial class MacaroonsItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Macaroons"; } }
        public override string FriendlyNamePlural               { get { return "Macaroons"; } } 
        public override string Description                      { get { return "A small circular biscuit with a sweet huckleberry filling."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 16, Fat = 12, Protein = 7, Vitamins = 9};
        public override float Calories                          { get { return 250; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(LeavenedBakingSkill), 3)]    
    public partial class MacaroonsRecipe : Recipe
    {
        public MacaroonsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MacaroonsItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FlourItem>(typeof(LeavenedBakingEfficiencySkill), 10, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SimpleSyrupItem>(typeof(LeavenedBakingEfficiencySkill), 5, LeavenedBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<HuckleberryExtractItem>(typeof(LeavenedBakingEfficiencySkill), 10, LeavenedBakingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MacaroonsRecipe), Item.Get<MacaroonsItem>().UILink(), 8, typeof(LeavenedBakingSpeedSkill)); 
            this.Initialize("Macaroons", typeof(MacaroonsRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}