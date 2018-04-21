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
    public partial class PrintedSpaceShipObject : WorldObject
    {
        public override string FriendlyName { get { return "Printed SpaceShip"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Misc");                                 
            this.GetComponent<HousingComponent>().Set(PrintedSpaceShipItem.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class PrintedSpaceShipItem : WorldObjectItem<PrintedSpaceShipObject>
    {
        public override string FriendlyName { get { return "Printed SpaceShip"; } } 
        public override string Description { get { return "Small SpaceShip, put on the table"; } }

        static PrintedSpaceShipItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "General",
                                                    Val = 1,
                                                    TypeForRoomLimit = "Ornament",
                                                    DiminishingReturnPercent = 0.7f
                                                };}}       
    }

    [RequiresSkill(typeof(PrintingProductionSkill), 2)]
    public partial class PrintedSpaceShipRecipe : Recipe
    {
        public PrintedSpaceShipRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PrintedSpaceShipItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PrinterBoxItem>(typeof(PrintingProductionEfficiencySkill), 5, PrintingProductionEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(20, PrintingProductionSpeedSkill.MultiplicativeStrategy, typeof(PrintingProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(PrintedSpaceShipRecipe), Item.Get<PrintedSpaceShipItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<PrintedSpaceShipItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Printed SpaceShip", typeof(PrintedSpaceShipRecipe));
            CraftingComponent.AddRecipe(typeof(DPrinterObject), this);
        }
    }
}