// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerGeneratorComponent))]
    [RequireComponent(typeof(PowerGridNetworkComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class NuclearGeneratorObject : WorldObject
    {
        public override string FriendlyName { get { return "Nuclear Generator"; } }

        private static Type[] fuelTypeList = new Type[]
        {
            typeof(UraniumItem),
        };

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<MinimapComponent>().Initialize("Nuclear Generator");
            this.GetComponent<LinkComponent>().Initialize(10);
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTypeList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(100);
            this.GetComponent<PowerGridComponent>().Initialize(30, new ElectricPower());
            this.GetComponent<PowerGeneratorComponent>().Initialize(500000);
            this.GetComponent<PowerGridNetworkComponent>().Initialize(new Dictionary<Type, int> { { typeof(NuclearTowerObject), 2 }, { typeof(NuclearGeneratorObject), 1 } }, false);
        }
        static NuclearGeneratorObject()
        {
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(-2, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(2, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(-2, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(NuclearGeneratorObject), new BlockOccupancy(new Vector3i(2, 1, 0), typeof(WorldObjectBlock)));
        }
    }
}