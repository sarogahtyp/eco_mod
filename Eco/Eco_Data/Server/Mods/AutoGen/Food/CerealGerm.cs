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
    public partial class CerealGermItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Cereal Germ"; } }
        public override string Description                      { get { return "A by-product of milling, the germ is the reproductive part of the cereal that germinates."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 7, Protein = 0, Vitamins = 3};
        public override float Calories                          { get { return 20; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}