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
    public partial class RusticToiletObject : WorldObject
    {
        public override string FriendlyName { get { return "RusticToilet"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(RusticToiletItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static RusticToiletObject()
        {
            AddOccupancyList(typeof(RusticToiletObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class RusticToiletItem : WorldObjectItem<RusticToiletObject>
    {
        public override string FriendlyName { get { return "RusticToilet"; } } 
        public override string Description { get { return "Your Poop Counts"; } }

        static RusticToiletItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Bathroom",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Toilet",
                                                    DiminishingReturnPercent = 0.1f
                                                };}}       
    }

    [RequiresSkill(typeof(ClayProductionSkill), 4)]
    public partial class RusticToiletRecipe : Recipe
    {
        public RusticToiletRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RusticToiletItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CeramicItem>(typeof(ClayProductionEfficiencySkill), 10, ClayProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CopperPipeItem>(typeof(ClayProductionEfficiencySkill), 1, ClayProductionEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CeramicPolishItem>(typeof(ClayProductionEfficiencySkill), 5, ClayProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(20, ClayProductionSpeedSkill.MultiplicativeStrategy, typeof(ClayProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(RusticToiletRecipe), Item.Get<RusticToiletItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<RusticToiletItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("RusticToilet", typeof(RusticToiletRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}