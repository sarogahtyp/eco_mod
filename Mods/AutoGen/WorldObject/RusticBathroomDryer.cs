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
    public partial class RusticBathroomDryerObject : WorldObject
    {
        public override string FriendlyName { get { return "Rustic Bathroom Dryer"; } }


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");
            this.GetComponent<HousingComponent>().Set(RusticBathroomDryerItem.HousingVal);



        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class RusticBathroomDryerItem : WorldObjectItem<RusticBathroomDryerObject>
    {
        public override string FriendlyName { get { return "Rustic Bathroom Dryer"; } } 
        public override string Description { get { return "Warm and Cool"; } }

        static RusticBathroomDryerItem()
        {
            
        }
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = "Bathroom",
                    Val = 2,
                    TypeForRoomLimit = "Dryer",
                    DiminishingReturnPercent = 0.1f
                };
            }
        }
    }


    [RequiresSkill(typeof(MetalworkingSkill), 4)]
    public partial class RusticBathroomDryerRecipe : Recipe
    {
        public RusticBathroomDryerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RusticBathroomDryerItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ClothItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(20, MetalworkingSpeedSkill.MultiplicativeStrategy, typeof(MetalworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(RusticBathroomDryerRecipe), Item.Get<RusticBathroomDryerItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<RusticBathroomDryerItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Rustic Bathroom Dryer", typeof(RusticBathroomDryerRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}