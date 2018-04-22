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
    public partial class RusticSmallNightstandObject : WorldObject
    {
        public override string FriendlyName { get { return "Rustic Small Nightstand"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(RusticSmallNightstandItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static RusticSmallNightstandObject()
        {
            AddOccupancyList(typeof(RusticSmallNightstandObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class RusticSmallNightstandItem : WorldObjectItem<RusticSmallNightstandObject>
    {
        public override string FriendlyName { get { return "Rustic Small Nightstand"; } } 
        public override string Description { get { return "You can't put things over this"; } }

        static RusticSmallNightstandItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Bedroom",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Stand",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 3)]
    public partial class RusticSmallNightstandRecipe : Recipe
    {
        public RusticSmallNightstandRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RusticSmallNightstandItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),  
				new CraftingElement<RivetItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPolishItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),				
            };
            SkillModifiedValue value = new SkillModifiedValue(10, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(RusticSmallNightstandRecipe), Item.Get<RusticSmallNightstandItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<RusticSmallNightstandItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Rustic Small Nightstand", typeof(RusticSmallNightstandRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}