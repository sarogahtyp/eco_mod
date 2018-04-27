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

    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(45)]
    [RequireRoomMaterialTier(4, 16)]
    public partial class DPrinterObject : WorldObject
    {
        public override string FriendlyName { get { return "D Printer"; } }


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");
            this.GetComponent<PowerConsumptionComponent>().Initialize(500);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<HousingComponent>().Set(DPrinterItem.HousingVal);
//			this.GetComponent<LinkComponent>().Initialize(10);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static DPrinterObject()
        {
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(2, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(2, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(0, 0, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(0, 1, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(1, 0, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(1, 1, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(2, 0, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(DPrinterObject), new BlockOccupancy(new Vector3i(2, 1, 1), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class DPrinterItem : WorldObjectItem<DPrinterObject>
    {
        public override string FriendlyName { get { return "3D Printer"; } }
        public override string Description { get { return "Wonderful Items For Your Housing"; } }

        static DPrinterItem()
        {

        }

        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = "Industrial",
                    Val = 0,
                    TypeForRoomLimit = "",
                    DiminishingReturnPercent = 0
                };
            }
        }
    }


    [RequiresSkill(typeof(ElectronicEngineeringSkill), 4)]
    public partial class DPrinterRecipe : Recipe
    {
        public DPrinterRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DPrinterItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ServoItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(ElectronicEngineeringEfficiencySkill), 10, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(300, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(DPrinterRecipe), Item.Get<DPrinterItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<DPrinterItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("3D Printer", typeof(DPrinterRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}