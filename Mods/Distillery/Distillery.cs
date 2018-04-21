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
    [RequireComponent(typeof(CraftingComponent))]               
    [RequireComponent(typeof(FuelSupplyComponent))]                      
    [RequireComponent(typeof(FuelConsumptionComponent))]                 
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                              
    [RequireRoomMaterialTier(2, 18)]        
    public partial class DistilleryObject : WorldObject
    {
        public override string FriendlyName { get { return "Distillery"; } } 


         private static Type[] fuelTypeList = new Type[]
        {
            typeof(LogItem),
            typeof(LumberItem),
            typeof(CharcoalItem),
            typeof(ArrowItem),
            typeof(BoardItem),
            typeof(CoalItem),
        };

        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");                                 
            this.GetComponent<FuelSupplyComponent>().Initialize(5, fuelTypeList);                           
            this.GetComponent<FuelConsumptionComponent>().Initialize(50);                    



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class DistilleryItem : WorldObjectItem<DistilleryObject>
    {
        public override string FriendlyName { get { return "Distillery"; } } 
        public override string Description { get { return "Let's get chemical, chemical"; } }

        static DistilleryItem()
        {
            
        }
        
    }


    [RequiresSkill(typeof(WoodworkingSkill), 3)]
    public partial class DistilleryRecipe : Recipe
    {
        public DistilleryRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DistilleryItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(WoodworkingEfficiencySkill), 30, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GlassItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<MortaredStoneItem>(typeof(WoodworkingEfficiencySkill), 50, WoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 50, WoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CopperIngotItem>(typeof(WoodworkingEfficiencySkill), 30, WoodworkingEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(120, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(DistilleryRecipe), Item.Get<DistilleryItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<DistilleryItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Distillery", typeof(DistilleryRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}