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
    public partial class BasicSaladItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Basic Salad"; } }
        public override string Description                      { get { return "A seemingly random assortment of wild plants that form a sort of salad."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 6, Fat = 4, Protein = 4, Vitamins = 6};
        public override float Calories                          { get { return 800; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

}