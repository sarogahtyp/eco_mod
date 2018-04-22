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
    public partial class ShowerObject : WorldObject
    {
        public override string FriendlyName { get { return "Shower"; } }


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");
            this.GetComponent<HousingComponent>().Set(ShowerItem.HousingVal);



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static ShowerObject()
        {
            AddOccupancyList(typeof(ShowerObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(ShowerObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(ShowerObject), new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class ShowerItem : WorldObjectItem<ShowerObject>
    {
        public override string FriendlyName { get { return "Shower"; } } 
        public override string Description { get { return "Refreshing Body and Soul"; } }

        static ShowerItem()
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
                    TypeForRoomLimit = "Shower",
                    DiminishingReturnPercent = 0.1f
                };
            }
        }
    }


    [RequiresSkill(typeof(MetalworkingSkill), 4)]
    public partial class ShowerRecipe : Recipe
    {
        public ShowerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ShowerItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(20, MetalworkingSpeedSkill.MultiplicativeStrategy, typeof(MetalworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ShowerRecipe), Item.Get<ShowerItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ShowerItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Shower", typeof(ShowerRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}