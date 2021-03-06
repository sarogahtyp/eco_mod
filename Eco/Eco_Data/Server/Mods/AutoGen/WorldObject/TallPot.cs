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
    public partial class TallPotObject : WorldObject
    {
        public override string FriendlyName { get { return "Tall Pot"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(TallPotItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static TallPotObject()
        {
            AddOccupancyList(typeof(TallPotObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class TallPotItem : WorldObjectItem<TallPotObject>
    {
        public override string FriendlyName { get { return "Tall Pot"; } } 
        public override string Description { get { return "Everdead!!"; } }

        static TallPotItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,
                                                    TypeForRoomLimit = "Decoration",
                                                    DiminishingReturnPercent = 0.9f
                                                };}}       
    }

    [RequiresSkill(typeof(ClayProductionSkill), 2)]
    public partial class TallPotRecipe : Recipe
    {
        public TallPotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<TallPotItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClayItem>(typeof(ClayProductionEfficiencySkill), 5, ClayProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<WoodPulpItem>(typeof(ClayProductionEfficiencySkill), 5, ClayProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(10, ClayProductionSpeedSkill.MultiplicativeStrategy, typeof(ClayProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(TallPotRecipe), Item.Get<TallPotItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<TallPotItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Tall Pot", typeof(TallPotRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}