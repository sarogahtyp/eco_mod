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
    public partial class PlasmaContainerItem : WorldObjectItem<PlasmaContainerObject>
    {
        public override string FriendlyName { get { return "Plasma Container"; } } 
        public override string Description { get { return "Prepare To Shoot"; } }

        static PlasmaContainerItem()
        {
            
        }
        
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Industrial",
                                                    Val = 0,
                                                    TypeForRoomLimit = "",
                                                    DiminishingReturnPercent = 0
                                                };}}       
    }


    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]
    public partial class PlasmaContainerRecipe : Recipe
    {
        public PlasmaContainerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PlasmaContainerItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlasmaBatteryItem>(typeof(ElectronicEngineeringEfficiencySkill), 100, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy), 
            };
            SkillModifiedValue value = new SkillModifiedValue(7200, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(PlasmaContainerRecipe), Item.Get<PlasmaContainerItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<PlasmaContainerItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Plasma Container", typeof(PlasmaContainerRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}