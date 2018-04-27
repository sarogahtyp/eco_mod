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
    [Weight(50)]                                          
    public partial class RawFishItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Raw Fish"; } }
        public override string Description                      { get { return "A fatty cut of raw fish."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 7, Protein = 3, Vitamins = 0};
        public override float Calories                          { get { return 200; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}