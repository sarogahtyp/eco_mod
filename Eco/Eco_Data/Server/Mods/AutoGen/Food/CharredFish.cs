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
    public partial class CharredFishItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Fish"; } }
        public override string FriendlyNamePlural               { get { return "Charred Fish"; } } 
        public override string Description                      { get { return "At least it doesn't have any scales any more."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 8, Protein = 12, Vitamins = 0};
        public override float Calories                          { get { return 550; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 4)]    
    public partial class CharredFishRecipe : Recipe
    {
        public CharredFishRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredFishItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(CampfireCookingEfficiencySkill), 3, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredFishRecipe), Item.Get<CharredFishItem>().UILink(), 3, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Charred Fish", typeof(CharredFishRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}