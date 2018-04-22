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
    public partial class FlowersCouchObject : WorldObject
    {
        public override string FriendlyName { get { return "Flowers Couch"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Housing");                                 
            this.GetComponent<HousingComponent>().Set(FlowersCouchItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static FlowersCouchObject()
        {
            AddOccupancyList(typeof(FlowersCouchObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class FlowersCouchItem : WorldObjectItem<FlowersCouchObject>
    {
        public override string FriendlyName { get { return "Flowers Couch"; } } 
        public override string Description { get { return ""; } }

        static FlowersCouchItem()
        {
            
        }
        
		[TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,
                                                    TypeForRoomLimit = "Seating",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }


    [RequiresSkill(typeof(ClothProductionSkill), 3)]
    public partial class FlowersCouchRecipe : Recipe
    {
        public FlowersCouchRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FlowersCouchItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(ClothProductionEfficiencySkill), 5, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(ClothProductionEfficiencySkill), 20, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ClothProductionEfficiencySkill), 10, ClothProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(5, ClothProductionSpeedSkill.MultiplicativeStrategy, typeof(ClothProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FlowersCouchRecipe), Item.Get<FlowersCouchItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FlowersCouchItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Flowers Couch", typeof(FlowersCouchRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}