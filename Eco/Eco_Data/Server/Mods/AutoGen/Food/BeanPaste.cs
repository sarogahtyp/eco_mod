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
    public partial class BeanPasteItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Bean Paste"; } }
        public override string FriendlyNamePlural               { get { return "Bean Paste"; } } 
        public override string Description                      { get { return "Smashed beans can work as a thickener or flavour enhancer."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 7, Protein = 5, Vitamins = 0};
        public override float Calories                          { get { return 40; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillProcessingSkill), 3)]    
    public partial class BeanPasteRecipe : Recipe
    {
        public BeanPasteRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BeanPasteItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeansItem>(typeof(MillProcessingEfficiencySkill), 15, MillProcessingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BeanPasteRecipe), Item.Get<BeanPasteItem>().UILink(), 5, typeof(MillProcessingSpeedSkill)); 
            this.Initialize("Bean Paste", typeof(BeanPasteRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}