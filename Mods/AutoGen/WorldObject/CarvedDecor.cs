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
    public partial class CarvedDecorObject : WorldObject
    {
        public override string FriendlyName { get { return "Carved Decor"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(CarvedDecorItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class CarvedDecorItem : WorldObjectItem<CarvedDecorObject>
    {
        public override string FriendlyName { get { return "Carved Decor"; } } 
        public override string Description { get { return "Standing Ornament, For Walls"; } }

        static CarvedDecorItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Ornament",
                                                    DiminishingReturnPercent = 0.8f
                                                };}}       
    }

    [RequiresSkill(typeof(PrintingProductionSkill), 1)]
    public partial class CarvedDecorRecipe : Recipe
    {
        public CarvedDecorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CarvedDecorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrinterBoxItem>(typeof(PrintingProductionEfficiencySkill), 5, PrintingProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(20, PrintingProductionSpeedSkill.MultiplicativeStrategy, typeof(PrintingProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(CarvedDecorRecipe), Item.Get<CarvedDecorItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<CarvedDecorItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Carved Decor", typeof(CarvedDecorRecipe));
            CraftingComponent.AddRecipe(typeof(DPrinterObject), this);
        }
    }
}