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
    public partial class CoffeeTableObject : WorldObject
    {
        public override string FriendlyName { get { return "Coffee Table"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(CoffeeTableItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static CoffeeTableObject()
        {
            AddOccupancyList(typeof(CoffeeTableObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(CoffeeTableObject), new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class CoffeeTableItem : WorldObjectItem<CoffeeTableObject>
    {
        public override string FriendlyName { get { return "Coffee Table"; } } 
        public override string Description { get { return "A small Table for Your LivingRoom."; } }

        static CoffeeTableItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Table",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 3)]
    public partial class CoffeeTableRecipe : Recipe
    {
        public CoffeeTableRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CoffeeTableItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(LumberWoodworkingEfficiencySkill), 30, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RivetItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPolishItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),	
            };
            SkillModifiedValue value = new SkillModifiedValue(10, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CoffeeTableRecipe), Item.Get<CoffeeTableItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CoffeeTableItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Coffee Table", typeof(CoffeeTableRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}