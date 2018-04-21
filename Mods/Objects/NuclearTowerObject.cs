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
using Eco.Gameplay.Pipes.LiquidComponents;
using Eco.Gameplay.Pipes.Gases;
using Eco.Shared.Utils;
using Eco.Gameplay.Pipes;

[Serialized]
[RequireComponent(typeof(MinimapComponent))]
[RequireComponent(typeof(PowerGridComponent))]
[RequireComponent(typeof(PowerGridNetworkComponent))]
[RequireComponent(typeof(PipeComponent))]
[RequireComponent(typeof(AttachmentComponent))]
[RequireComponent(typeof(SolidGroundComponent))]

public class NuclearTowerObject : WorldObject
{
    public float MinimapYaw { get { return 0.0f; } }
    public float MinimapScale { get { return 1.0f; } }
    public bool HideOnMinimap { get { return false; } }

    protected override void Initialize()
    {
        base.Initialize();
        this.GetComponent<MinimapComponent>().Initialize("Nuclear Tower");
        this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
        this.GetComponent<PowerGridNetworkComponent>().Initialize(new Dictionary<Type, int> { { typeof(NuclearTowerObject), 2 }, { typeof(NuclearGeneratorObject), 1 }, }, false);
		var tankList = new List<LiquidTank>();
            
            tankList.Add(new LiquidProducer("Chimney", typeof(SmogItem), 100,
                    null,                                                       
                    new Ray(0, 4, 0, Direction.Up),     
                        (float)(0.1f * SmogItem.SmogItemsPerCO2PPM) / TimeUtil.SecondsPerHour)); 
            
            
            
            this.GetComponent<PipeComponent>().Initialize(tankList);
    }

    static NuclearTowerObject()
    {
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 0, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 0, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 0, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 0, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 0, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 0, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 0, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 0, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 0, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 0, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 0, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 0, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 0, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 0, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 0, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 0, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 0, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 1, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 1, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 1, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 1, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 1, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 1, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 1, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 1, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 1, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 1, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 1, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 1, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 1, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 1, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 1, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 1, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 1, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 2, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 2, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 2, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 2, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 2, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 2, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 2, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 2, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 2, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 2, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 2, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 2, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 2, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 2, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 2, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 2, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 2, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 2, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 2, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 2, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 2, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 3, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 3, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 3, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 3, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 3, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 3, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 3, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 3, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 3, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 3, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 3, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 3, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 3, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 3, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 3, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 3, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 3, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 3, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 3, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 3, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 3, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 3, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 3, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 3, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 3, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 4, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 4, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 4, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 4, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 4, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 4, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 4, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 4, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 4, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 4, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 4, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 4, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 4, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 4, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 4, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 4, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 4, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 4, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 4, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 4, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 4, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 4, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 4, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 4, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 4, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 5, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 5, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 5, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 5, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 5, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 5, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 5, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 5, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 5, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 5, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 5, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 5, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 5, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 5, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 5, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 5, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 5, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 5, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 5, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 5, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 5, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 5, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 5, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 5, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 5, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 6, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 6, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 6, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 6, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 6, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 6, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 6, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 6, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 6, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 6, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 6, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 6, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 6, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 6, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 6, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 6, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 6, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 6, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 6, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 6, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 6, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 6, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 6, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 6, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 6, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 7, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 7, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 7, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 7, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 7, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 7, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 7, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 7, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 7, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 7, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 7, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 7, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 7, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 7, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 7, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 7, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 7, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 7, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 7, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 7, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 7, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 7, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 7, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 7, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 7, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 8, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 8, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 8, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 8, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 8, 0), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 8, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 8, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 8, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 8, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 8, 1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 8, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 8, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 8, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 8, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 8, 2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 8, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 8, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 8, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 8, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 8, -1), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-2, 8, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(-1, 8, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(0, 8, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(1, 8, -2), typeof(WorldObjectBlock)));
        AddOccupancyList(typeof(NuclearTowerObject), new BlockOccupancy(new Vector3i(2, 8, -2), typeof(WorldObjectBlock)));
    }
}