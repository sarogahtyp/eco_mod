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
    [Weight(10)]                                          
    [Yield(typeof(CriminiMushroomsItem), typeof(WetlandsWandererSkill), new float[] {1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f})]      
    public partial class CriminiMushroomsItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Crimini Mushrooms"; } }
        public override string Description                      { get { return "Edible mushrooms that are quite tasty."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 1, Protein = 3, Vitamins = 1};
        public override float Calories                          { get { return 20; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}