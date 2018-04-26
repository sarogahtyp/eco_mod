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
    [Yield(typeof(BullrushSeedItem), typeof(GrasslandGathererSkill), new float[] { 1f, 1.2f, 1.4f, 1.6f, 1.8f, 2f })]  
    [MaxStackSize(500)]
    [Weight(10)]  
    public partial class BullrushSeedItem : SeedItem
    {
        static BullrushSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Bullrush Seed"; } }
        public override string Description  { get { return "Plant to grow bullrush."; } }
        public override string SpeciesName  { get { return "Bullrush"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class BullrushSeedPackItem : SeedPackItem
    {
        static BullrushSeedPackItem() { }

        public override string FriendlyName { get { return "Bullrush Seed Pack"; } }
        public override string Description  { get { return "Plant to grow bullrush."; } }
        public override string SpeciesName  { get { return "Bullrush"; } }
    }

}