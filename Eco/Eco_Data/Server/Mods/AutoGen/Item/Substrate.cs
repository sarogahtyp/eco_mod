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

    [RequiresSkill(typeof(ElectronicEngineeringSkill), 2)]   
    public partial class SubstrateRecipe : Recipe
    {
        public SubstrateRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SubstrateItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FiberglassItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<EpoxyItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<NitricAcidItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SubstrateRecipe), Item.Get<SubstrateItem>().UILink(), 5, typeof(ElectronicEngineeringSpeedSkill));    
            this.Initialize("Substrate", typeof(SubstrateRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(1000)]      
    [Currency]              
    public partial class SubstrateItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Substrate"; } }
        public override string Description { get { return "The foundation material for complex electronics."; } }

    }

}