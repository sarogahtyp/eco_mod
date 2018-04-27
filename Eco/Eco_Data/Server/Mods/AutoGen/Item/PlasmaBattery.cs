namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]   
    public partial class PlasmaBatteryRecipe : Recipe
    {
        public PlasmaBatteryRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PlasmaBatteryItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlasticItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 5, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<LiquidNitrogenItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PlasmaBatteryRecipe), Item.Get<PlasmaBatteryItem>().UILink(), 360, typeof(CastingSpeedSkill));    
            this.Initialize("PlasmaBattery", typeof(PlasmaBatteryRecipe));

            CraftingComponent.AddRecipe(typeof(PlasmaChargerObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(2000)]
    public partial class PlasmaBatteryItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Plasma Battery"; } }
        public override string Description { get { return "The Ultimate Battery"; } }

    }

}