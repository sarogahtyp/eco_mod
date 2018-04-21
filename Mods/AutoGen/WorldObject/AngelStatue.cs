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
    public partial class AngelStatueObject : WorldObject
    {
        public override string FriendlyName { get { return "Angel Statue"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(AngelStatueItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static AngelStatueObject()
        {
            AddOccupancyList(typeof(AngelStatueObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(AngelStatueObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(AngelStatueObject), new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class AngelStatueItem : WorldObjectItem<AngelStatueObject>
    {
        public override string FriendlyName { get { return "Angel Statue"; } } 
        public override string Description { get { return "Big Size!!"; } }

        static AngelStatueItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Decoration",
                                                    DiminishingReturnPercent = 0.9f
                                                };}}       
    }

    [RequiresSkill(typeof(ClayProductionSkill), 3)]
    public partial class AngelStatueRecipe : Recipe
    {
        public AngelStatueRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AngelStatueItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CeramicItem>(typeof(ClayProductionEfficiencySkill), 20, ClayProductionEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CeramicPolishItem>(typeof(ClayProductionEfficiencySkill), 5, ClayProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(40, ClayProductionSpeedSkill.MultiplicativeStrategy, typeof(ClayProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(AngelStatueRecipe), Item.Get<AngelStatueItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<AngelStatueItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Angel Statue", typeof(AngelStatueRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}