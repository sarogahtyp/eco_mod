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
    public partial class AcornPowderItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Acorn Powder"; } }
        public override string FriendlyNamePlural               { get { return "Acorn Powder"; } } 
        public override string Description                      { get { return "Powdered acorn."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 2, Protein = 5, Vitamins = 5};
        public override float Calories                          { get { return 40; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillProcessingSkill), 4)]    
    public partial class AcornPowderRecipe : Recipe
    {
        public AcornPowderRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AcornPowderItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<AcornItem>(typeof(MillProcessingEfficiencySkill), 10, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AcornPowderRecipe), Item.Get<AcornPowderItem>().UILink(), 5, typeof(MillProcessingSpeedSkill)); 
            this.Initialize("Acorn Powder", typeof(AcornPowderRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}