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
    [Weight(200)]
    public partial class FishTacoItem :
        FoodItem
    {
        public override string FriendlyName { get { return "Fish Taco"; } }
        public override string Description { get { return "A tasty treat made from corn tortillas and fish."; } }

        private static Nutrients nutrition = new Nutrients() { Carbs = 13, Fat = 6, Protein = 9, Vitamins = 14 };
        public override float Calories { get { return 650; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }

    [RequiresSkill(typeof(CulinaryArtsSkill), 4)]
    public partial class FishTacoRecipe : Recipe
    {
        public FishTacoRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FishTacoItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RawFishItem>(typeof(CulinaryArtsEfficiencySkill), 30, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TortillaItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<WildMixItem>(typeof(CulinaryArtsEfficiencySkill), 5, CulinaryArtsEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(FishTacoRecipe), Item.Get<FishTacoItem>().UILink(), 15, typeof(CulinaryArtsSpeedSkill));
            this.Initialize("Fish Taco", typeof(FishTacoRecipe));
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }
    }
}