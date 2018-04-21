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
    [RequireComponent(typeof(HousingComponent))]                          
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class Arcade4Players2Object : WorldObject
    {
        public override string FriendlyName { get { return "Arcade 4 Players 2"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<HousingComponent>().Set(Arcade4Players2Item.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static Arcade4Players2Object()
        {
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(0, 0, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(1, 0, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(0, 1, 1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(Arcade4Players2Object), new BlockOccupancy(new Vector3i(1, 1, 1), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class Arcade4Players2Item : WorldObjectItem<Arcade4Players2Object>
    {
        public override string FriendlyName { get { return "Arcade 4 Players 2"; } } 
        public override string Description { get { return "Don't do it at Home.."; } }

        static Arcade4Players2Item()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 3,
                                                    TypeForRoomLimit = "Entertainment",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }

    [RequiresSkill(typeof(ElectronicProductionSkill), 4)]
    public partial class Arcade4Players2Recipe : Recipe
    {
        public Arcade4Players2Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<Arcade4Players2Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(ElectronicProductionEfficiencySkill), 10, ElectronicProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(ElectronicProductionEfficiencySkill), 20, ElectronicProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<LumberItem>(typeof(ElectronicProductionEfficiencySkill), 40, ElectronicProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(40, ElectronicProductionSpeedSkill.MultiplicativeStrategy, typeof(ElectronicProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(Arcade4Players2Recipe), Item.Get<Arcade4Players2Item>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<Arcade4Players2Item>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Arcade 4 Players 2", typeof(Arcade4Players2Recipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}