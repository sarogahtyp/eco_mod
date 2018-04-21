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
    public partial class AllInOnePCObject : WorldObject
    {
        public override string FriendlyName { get { return "All In One PC"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");
            this.GetComponent<PowerConsumptionComponent>().Initialize(100);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<HousingComponent>().Set(AllInOnePCItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class AllInOnePCItem : WorldObjectItem<AllInOnePCObject>
    {
        public override string FriendlyName { get { return "All In One PC"; } } 
        public override string Description { get { return "Nothing to Play.."; } }

        static AllInOnePCItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Entertainment",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }

    [RequiresSkill(typeof(ElectronicProductionSkill), 3)]
    public partial class AllInOnePCRecipe : Recipe
    {
        public AllInOnePCRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AllInOnePCItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(ElectronicProductionEfficiencySkill), 5, ElectronicProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(ElectronicProductionEfficiencySkill), 10, ElectronicProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PlasticItem>(typeof(ElectronicProductionEfficiencySkill), 5, ElectronicProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(40, ElectronicProductionSpeedSkill.MultiplicativeStrategy, typeof(ElectronicProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(AllInOnePCRecipe), Item.Get<AllInOnePCItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<AllInOnePCItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("All In One PC", typeof(AllInOnePCRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}