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
    public partial class MilkItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Milk"; } }
        public override string FriendlyNamePlural               { get { return "Milk"; } } 
        public override string Description                      { get { return "Milk, although maybe not from an animal."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 3, Fat = 7, Protein = 10, Vitamins = 0};
        public override float Calories                          { get { return 120; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}