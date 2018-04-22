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
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PowerGridComponent))] 
    [RequireComponent(typeof(PowerConsumptionComponent))]	
    [RequireComponent(typeof(PublicStorageComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class CentralStorageObject : 
        WorldObject    
    {
        public override string FriendlyName { get { return "Central Storage"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Storage");                                 
			this.GetComponent<LinkComponent>().Initialize(10);
			this.GetComponent<PowerConsumptionComponent>().Initialize(50);                      
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
			
			
            var storage = this.GetComponent<PublicStorageComponent>();
			storage.Initialize(100);
            

        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class CentralStorageItem : WorldObjectItem<CentralStorageObject>
    {
        public override string FriendlyName { get { return "Central Storage"; } } 
        public override string Description  { get { return  "A huge container for everything."; } }

        static CentralStorageItem()
        {
            
        }

    }


    [RequiresSkill(typeof(BasicCraftingSkill), 1)]
    public partial class CentralStorageRecipe : Recipe
    {
        public CentralStorageRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CentralStorageItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 50, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CircuitItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CopperWiringItem>(typeof(ElectronicEngineeringEfficiencySkill), 100, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<LogisticRobotItem>(typeof(ElectronicEngineeringEfficiencySkill), 1, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RivetItem>(typeof(ElectronicEngineeringEfficiencySkill), 100, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<GearboxItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(2, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CentralStorageRecipe), Item.Get<CentralStorageItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CentralStorageItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Central Storage", typeof(CentralStorageRecipe));
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }
}