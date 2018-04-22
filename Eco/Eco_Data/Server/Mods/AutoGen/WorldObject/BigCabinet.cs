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
    [RequireComponent(typeof(HousingComponent))]                          
    [RequireComponent(typeof(PublicStorageComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class BigCabinetObject : WorldObject
    {
        public override string FriendlyName { get { return "Big Cabinet"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Housing");                                 
            this.GetComponent<HousingComponent>().Set(BigCabinetItem.HousingVal);
            this.GetComponent<LinkComponent>().Initialize(10);

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(32);
            storage.Storage.AddRestriction(new NotCarriedRestriction()); // can't store block or large items


        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static BigCabinetObject()
        {
            AddOccupancyList(typeof(BigCabinetObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(BigCabinetObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(BigCabinetObject), new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(BigCabinetObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(BigCabinetObject), new BlockOccupancy(new Vector3i(1, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(BigCabinetObject), new BlockOccupancy(new Vector3i(1, 2, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class BigCabinetItem : WorldObjectItem<BigCabinetObject>
    {
        public override string FriendlyName { get { return "Big Cabinet"; } } 
        public override string Description { get { return "Store Your Clothes"; } }

        static BigCabinetItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Bedroom",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Cabinet",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 4)]
    public partial class BigCabinetRecipe : Recipe
    {
        public BigCabinetRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BigCabinetItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 40, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(LumberWoodworkingEfficiencySkill), 40, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RivetItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPolishItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(20, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(BigCabinetRecipe), Item.Get<BigCabinetItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<BigCabinetItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Big Cabinet", typeof(BigCabinetRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}