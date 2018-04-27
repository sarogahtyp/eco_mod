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
    public partial class FishsticksItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fishsticks"; } }
        public override string FriendlyNamePlural               { get { return "Fishsticks"; } } 
        public override string Description                      { get { return "Kanye West still does not understand this."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 6, Protein = 10, Vitamins = 3};
        public override float Calories                          { get { return 1000; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(BasicBakingSkill), 2)]    
    public partial class FishsticksRecipe : Recipe
    {
        public FishsticksRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FishsticksItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FishFilletItem>(typeof(BasicBakingEfficiencySkill), 5, BasicBakingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CornmealItem>(typeof(BasicBakingEfficiencySkill), 20, BasicBakingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FishsticksRecipe), Item.Get<FishsticksItem>().UILink(), 3, typeof(BasicBakingSpeedSkill)); 
            this.Initialize("Fishsticks", typeof(FishsticksRecipe));
            CraftingComponent.AddRecipe(typeof(BakeryOvenObject), this);
        }
    }
}