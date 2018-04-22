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
    public partial class SimpleDeskObject : WorldObject
    {
        public override string FriendlyName { get { return "Simple Desk"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(SimpleDeskItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static SimpleDeskObject()
        {
            AddOccupancyList(typeof(SimpleDeskObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(SimpleDeskObject), new BlockOccupancy(new Vector3i(0, 0, 1), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class SimpleDeskItem : WorldObjectItem<SimpleDeskObject>
    {
        public override string FriendlyName { get { return "Simple Desk"; } } 
        public override string Description { get { return "Simple Desk"; } }

        static SimpleDeskItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,
                                                    TypeForRoomLimit = "Desk",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }


    [RequiresSkill(typeof(WoodworkingSkill), 3)]
    public partial class SimpleDeskRecipe : Recipe
    {
        public SimpleDeskRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SimpleDeskItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 5, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 10, WoodworkingEfficiencySkill.MultiplicativeStrategy),  
				new CraftingElement<RivetItem>(typeof(WoodworkingEfficiencySkill), 5, WoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<OilItem>(typeof(WoodworkingEfficiencySkill), 5, WoodworkingEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(10, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(SimpleDeskRecipe), Item.Get<SimpleDeskItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<SimpleDeskItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Simple Desk", typeof(SimpleDeskRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}