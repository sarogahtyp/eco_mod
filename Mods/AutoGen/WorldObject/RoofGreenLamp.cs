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

    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(PowerGridComponent))]              
    [RequireComponent(typeof(PowerConsumptionComponent))]                     
    [RequireComponent(typeof(HousingComponent))]                          
    public partial class RoofGreenLampObject : WorldObject
    {
        public override string FriendlyName { get { return "Roof Green Lamp"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Lights");                                 
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());        
            this.GetComponent<HousingComponent>().Set(RoofGreenLampItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class RoofGreenLampItem : WorldObjectItem<RoofGreenLampObject>
    {
        public override string FriendlyName { get { return "Roof Green Lamp"; } } 
        public override string Description { get { return "A directional Light that requires electricity to run."; } }

        static RoofGreenLampItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Lights",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }


    [RequiresSkill(typeof(ElectronicEngineeringSkill), 3)]
    public partial class RoofGreenLampRecipe : Recipe
    {
        public RoofGreenLampRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RoofGreenLampItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 15, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CircuitItem>(typeof(ElectronicEngineeringEfficiencySkill), 2, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CopperWiringItem>(typeof(ElectronicEngineeringEfficiencySkill), 100, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(1, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(RoofGreenLampRecipe), Item.Get<RoofGreenLampItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<RoofGreenLampItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Roof Green Lamp", typeof(RoofGreenLampRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}