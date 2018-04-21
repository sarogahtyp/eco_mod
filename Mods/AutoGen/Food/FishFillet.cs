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
    [Weight(500)]                                          
    public partial class FishFilletItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "FishFillet"; } }
        public override string Description                      { get { return "Carefully butchered fish, ready to cook."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 6, Protein = 4, Vitamins = 0};
        public override float Calories                          { get { return 600; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MeatPrepSkill), 3)]    
    public partial class FishFilletRecipe : Recipe
    {
        public FishFilletRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FishFilletItem>(),
               
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(MeatPrepEfficiencySkill), 20, MeatPrepEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FishFilletRecipe), Item.Get<FishFilletItem>().UILink(), 2, typeof(MeatPrepSpeedSkill)); 
            this.Initialize("Fish Fillet", typeof(FishFilletRecipe));
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }
    }
}