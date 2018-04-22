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
    [RequireRoomMaterialTier(4, 45)]
    public partial class PlasmaChargerObject : WorldObject
    {
        public override string FriendlyName { get { return "Plasma Charger"; } }


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");
            this.GetComponent<PowerConsumptionComponent>().Initialize(500000);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<HousingComponent>().Set(PlasmaChargerItem.HousingVal);
            this.GetComponent<LinkComponent>().Initialize(10);


        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static PlasmaChargerObject()
        {
            AddOccupancyList(typeof(PlasmaChargerObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(PlasmaChargerObject), new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(PlasmaChargerObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class PlasmaChargerItem : WorldObjectItem<PlasmaChargerObject>
    {
        public override string FriendlyName { get { return "Plasma Charger"; } }
        public override string Description { get { return "Prepare Batteries for Plasma Accumulator"; } }

        static PlasmaChargerItem()
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
    public partial class PlasmaChargerRecipe : Recipe
    {
        public PlasmaChargerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PlasmaChargerItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 40, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(IndustrialEngineeringEfficiencySkill), 30, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(3600, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(PlasmaChargerRecipe), Item.Get<PlasmaChargerItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<PlasmaChargerItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Plasma Charger", typeof(PlasmaChargerRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}