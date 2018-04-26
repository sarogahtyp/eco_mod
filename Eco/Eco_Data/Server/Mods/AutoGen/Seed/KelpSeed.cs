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
	[MaxStackSize(500)]
	[Weight(10)]  
    public partial class KelpSeedItem : SeedItem
    {
        static KelpSeedItem() { }
        
        private static Nutrients nutrition = new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0 };

        public override string FriendlyName { get { return "Kelp Seed"; } }
        public override string Description  { get { return "Plant to grow kelp."; } }
        public override string SpeciesName  { get { return "Kelp"; } }

        public override float Calories { get { return 0; } }
        public override Nutrients Nutrition { get { return nutrition; } }
    }


    [Serialized]
    [Category("Hidden")]
    [Weight(10)]  
    public partial class KelpSeedPackItem : SeedPackItem
    {
        static KelpSeedPackItem() { }

        public override string FriendlyName { get { return "Kelp Seed Pack"; } }
        public override string Description  { get { return "Plant to grow kelp."; } }
        public override string SpeciesName  { get { return "Kelp"; } }
    }

}