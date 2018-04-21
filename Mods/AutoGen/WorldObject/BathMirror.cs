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
    public partial class BathMirrorObject : WorldObject
    {
        public override string FriendlyName { get { return "Bathroom Mirror"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(BathMirrorItem.HousingVal);


        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class BathMirrorItem : WorldObjectItem<BathMirrorObject>
    {
        public override string FriendlyName { get { return "Bathroom Mirror"; } } 
        public override string Description { get { return "You're so pretty"; } }

        static BathMirrorItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Bathroom",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Mirror",
                                                    DiminishingReturnPercent = 0.1f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 2)]
    public partial class BathMirrorRecipe : Recipe
    {
        public BathMirrorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BathMirrorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GlassItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(10, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(BathMirrorRecipe), Item.Get<BathMirrorItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<BathMirrorItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Bathroom Mirror", typeof(BathMirrorRecipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}