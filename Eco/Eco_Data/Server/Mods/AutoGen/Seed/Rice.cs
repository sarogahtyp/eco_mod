namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;

    [Serialized]
    [Yield(typeof(RiceItem), typeof(WetlandsWandererSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [Weight(10)]  
    public partial class RiceItem : SeedItem
    {
        static RiceItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 7, Fat = 0, Protein = 1, Vitamins = 0 };

        public override string FriendlyName { get { return "Rice"; } }
        public override string Description  { get { return "Plant to grow rice."; } }
        public override string SpeciesName  { get { return "Rice"; } }

        public override float Calories { get { return 9; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class RicePackItem : SeedPackItem
    {
        static RicePackItem() { }

        public override string FriendlyName { get { return "Rice Pack"; } }
        public override string Description  { get { return "Plant to grow rice."; } }
        public override string SpeciesName  { get { return "Rice"; } }
    }

}