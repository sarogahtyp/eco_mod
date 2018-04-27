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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 2)]   
    public partial class CopperWiringRecipe : Recipe
    {
        public CopperWiringRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CopperWiringItem>(2),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 5, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<OilItem>(typeof(MechanicsComponentsEfficiencySkill), 1, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
					
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperWiringRecipe), Item.Get<CopperWiringItem>().UILink(), 2, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Copper Wiring", typeof(CopperWiringRecipe));

            CraftingComponent.AddRecipe(typeof(MachineShopObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(200)]      
    [Currency]              
    public partial class CopperWiringItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Copper Wiring"; } }
        public override string FriendlyNamePlural { get { return "Copper Wiring"; } } 
        public override string Description { get { return "A length of conductive wire useful for a variety of purposes."; } }

    }

}