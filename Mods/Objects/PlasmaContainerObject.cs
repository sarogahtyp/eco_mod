// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Objects;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

[Serialized]
[RequireComponent(typeof(MinimapComponent))]
[RequireComponent(typeof(PowerGridComponent))]
[RequireComponent(typeof(PowerGridNetworkComponent))]
[RequireComponent(typeof(SolidGroundComponent))]
public class PlasmaContainerObject : WorldObject
{
    public float MinimapYaw { get { return 0.0f; } }
    public float MinimapScale { get { return 1.0f; } }
    public bool HideOnMinimap { get { return false; } }

    protected override void Initialize()
    {
        base.Initialize();
        this.GetComponent<MinimapComponent>().Initialize("Plasma Container");
        this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
        this.GetComponent<PowerGridNetworkComponent>().Initialize(new Dictionary<Type, int> { { typeof(LaserObject), 4 }, { typeof(ComputerLabObject), 1 }, { typeof(PlasmaContainerObject), 1 } }, false);
    }

    static PlasmaContainerObject()
    {
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(0, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(1, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(0, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(1, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(1, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(0, 2, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(PlasmaContainerObject), new BlockOccupancy(new Vector3i(1, 2, 1), typeof(WorldObjectBlock)));
    }
}