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
    public partial class ModernChairObject : WorldObject
    {
        public override string FriendlyName { get { return "Modern Chair"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Housing");                                 
            this.GetComponent<HousingComponent>().Set(ModernChairItem.HousingVal);                                


        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static ModernChairObject()
        {
            AddOccupancyList(typeof(ModernChairObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class ModernChairItem : WorldObjectItem<ModernChairObject>
    {
        public override string FriendlyName { get { return "Modern Chair"; } } 
        public override string Description { get { return ""; } }

        static ModernChairItem()
        {
            
        }
        
		[TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Seating",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }


    [RequiresSkill(typeof(ClothProductionSkill), 4)]
    public partial class ModernChairRecipe : Recipe
    {
        public ModernChairRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ModernChairItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelPipeItem>(typeof(ClothProductionEfficiencySkill), 10, ClothProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(ClothProductionEfficiencySkill), 10, ClothProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(10, ClothProductionSpeedSkill.MultiplicativeStrategy, typeof(ClothProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ModernChairRecipe), Item.Get<ModernChairItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ModernChairItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Modern Chair", typeof(ModernChairRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}