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
    public partial class SmallLivingRoomStandObject : WorldObject
    {
        public override string FriendlyName { get { return "Small LivingRoom Stand"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(SmallLivingRoomStandItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static SmallLivingRoomStandObject()
        {
            AddOccupancyList(typeof(SmallLivingRoomStandObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(SmallLivingRoomStandObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class SmallLivingRoomStandItem : WorldObjectItem<SmallLivingRoomStandObject>
    {
        public override string FriendlyName { get { return "Small LivingRoom Stand"; } } 
        public override string Description { get { return "A small LivingRoom Stand for placing things on."; } }

        static SmallLivingRoomStandItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,
                                                    TypeForRoomLimit = "Stand",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }


    [RequiresSkill(typeof(WoodworkingSkill), 3)]
    public partial class SmallLivingRoomStandRecipe : Recipe
    {
        public SmallLivingRoomStandRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SmallLivingRoomStandItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 10, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RivetItem>(typeof(WoodworkingEfficiencySkill), 5, WoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<OilItem>(typeof(WoodworkingEfficiencySkill), 5, WoodworkingEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(10, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(SmallLivingRoomStandRecipe), Item.Get<SmallLivingRoomStandItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<SmallLivingRoomStandItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Small LivingRoom Stand", typeof(SmallLivingRoomStandRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}