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
    [Weight(100)]                                          
    public partial class CharredBeetItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Charred Beet"; } }
        public override string Description                      { get { return "Perhaps not the best raw vegetable to char, this beet seems to have held up well enough."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 4, Protein = 2, Vitamins = 8};
        public override float Calories                          { get { return 470; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CampfireCookingSkill), 3)]    
    public partial class CharredBeetRecipe : Recipe
    {
        public CharredBeetRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharredBeetItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetItem>(typeof(CampfireCookingEfficiencySkill), 3, CampfireCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharredBeetRecipe), Item.Get<CharredBeetItem>().UILink(), 2, typeof(CampfireCookingSpeedSkill)); 
            this.Initialize("Charred Beet", typeof(CharredBeetRecipe));
            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }
}