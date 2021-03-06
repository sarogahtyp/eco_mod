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
    [RequireComponent(typeof(HousingComponent))]                          
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class ElegantLivingRoomStandObject : WorldObject
    {
        public override string FriendlyName { get { return "Elegant LivingRoom Stand"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(ElegantLivingRoomStandItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static ElegantLivingRoomStandObject()
        {
            AddOccupancyList(typeof(ElegantLivingRoomStandObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(ElegantLivingRoomStandObject), new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(ElegantLivingRoomStandObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class ElegantLivingRoomStandItem : WorldObjectItem<ElegantLivingRoomStandObject>
    {
        public override string FriendlyName { get { return "Elegant LivingRoom Stand"; } } 
        public override string Description { get { return "A small LivingRoom Stand for placing things on."; } }

        static ElegantLivingRoomStandItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Stand",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 4)]
    public partial class ElegantLivingRoomStandRecipe : Recipe
    {
        public ElegantLivingRoomStandRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElegantLivingRoomStandItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 20, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(LumberWoodworkingEfficiencySkill), 40, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy), 
				new CraftingElement<RivetItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPolishItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),				
            };
            SkillModifiedValue value = new SkillModifiedValue(20, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ElegantLivingRoomStandRecipe), Item.Get<ElegantLivingRoomStandItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ElegantLivingRoomStandItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Elegant LivingRoom Stand", typeof(ElegantLivingRoomStandRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}