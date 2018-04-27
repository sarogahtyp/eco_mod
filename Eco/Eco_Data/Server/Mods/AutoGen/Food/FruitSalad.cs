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
    [Weight(300)]                                          
    public partial class FruitSaladItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Fruit Salad"; } }
        public override string Description                      { get { return "While tomatoes are fruits, you don't usually put them in fruit salads."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 8, Fat = 2, Protein = 2, Vitamins = 10};
        public override float Calories                          { get { return 900; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}