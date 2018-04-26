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
    [Weight(10)]
    [Yield(typeof(PricklyPearFruitItem), typeof(DesertDrifterSkill), new float[] {1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f})]      
    public partial class PricklyPearFruitItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Prickly Pear Fruit"; } }
        public override string Description                      { get { return "A succulent fruit coated in a rather terrifying array of spines."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 2, Fat = 1, Protein = 1, Vitamins = 3};
        public override float Calories                          { get { return 19; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}