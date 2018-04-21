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
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class FlowersDoubleBedObject : WorldObject
    {
        public override string FriendlyName { get { return "Flowers Double Bed"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(FlowersDoubleBedItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static FlowersDoubleBedObject()
        {
            AddOccupancyList(typeof(FlowersDoubleBedObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(FlowersDoubleBedObject), new BlockOccupancy(new Vector3i(1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(FlowersDoubleBedObject), new BlockOccupancy(new Vector3i(0, 0, -1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(FlowersDoubleBedObject), new BlockOccupancy(new Vector3i(1, 0, -1), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(FlowersDoubleBedObject), new BlockOccupancy(new Vector3i(0, 0, -2), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(FlowersDoubleBedObject), new BlockOccupancy(new Vector3i(1, 0, -2), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class FlowersDoubleBedItem : WorldObjectItem<FlowersDoubleBedObject>
    {
        public override string FriendlyName { get { return "Flowers Double Bed"; } } 
        public override string Description { get { return ""; } }

        static FlowersDoubleBedItem()
        {
            
        }
        
		[TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Bedroom",
                                                    Val = 4,
                                                    TypeForRoomLimit = "Bed",
                                                    DiminishingReturnPercent = 0.4f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 4)]
    public partial class FlowersDoubleBedRecipe : Recipe
    {
        public FlowersDoubleBedRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FlowersDoubleBedItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 40, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(LumberWoodworkingEfficiencySkill), 40, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RivetItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPolishItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),				
            };
            SkillModifiedValue value = new SkillModifiedValue(10, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FlowersDoubleBedRecipe), Item.Get<FlowersDoubleBedItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FlowersDoubleBedItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Flowers Double Bed", typeof(FlowersDoubleBedRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}