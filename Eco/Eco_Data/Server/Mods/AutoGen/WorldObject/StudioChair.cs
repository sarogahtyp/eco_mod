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
    public partial class StudioChairObject : WorldObject
    {
        public override string FriendlyName { get { return "Studio Chair"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(StudioChairItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static StudioChairObject()
        {
            AddOccupancyList(typeof(StudioChairObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class StudioChairItem : WorldObjectItem<StudioChairObject>
    {
        public override string FriendlyName { get { return "Studio Chair"; } } 
        public override string Description { get { return "Plastic Made Studio Chair"; } }

        static StudioChairItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Seating",
                                                    DiminishingReturnPercent = 0.9f
                                                };}}       
    }

    [RequiresSkill(typeof(PrintingProductionSkill), 4)]
    public partial class StudioChairRecipe : Recipe
    {
        public StudioChairRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StudioChairItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrinterBoxItem>(typeof(PrintingProductionEfficiencySkill), 10, PrintingProductionEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ClothItem>(typeof(PrintingProductionEfficiencySkill), 5, PrintingProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(20, PrintingProductionSpeedSkill.MultiplicativeStrategy, typeof(PrintingProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(StudioChairRecipe), Item.Get<StudioChairItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<StudioChairItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Studio Chair", typeof(StudioChairRecipe));
            CraftingComponent.AddRecipe(typeof(DPrinterObject), this);
        }
    }
}