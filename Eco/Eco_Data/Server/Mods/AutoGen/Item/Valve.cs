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

    [RequiresSkill(typeof(MechanicalEngineeringSkill), 3)]   
    public partial class ValveRecipe : Recipe
    {
        public ValveRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ValveItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelPipeItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<GearItem>(typeof(MechanicsAssemblyEfficiencySkill), 10, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(MechanicsAssemblyEfficiencySkill), 5, MechanicsAssemblyEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ValveRecipe), Item.Get<ValveItem>().UILink(), 2, typeof(MechanicsAssemblySpeedSkill));    
            this.Initialize("Valve", typeof(ValveRecipe));

            CraftingComponent.AddRecipe(typeof(MachineShopObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(1000)]      
    [Currency]              
    public partial class ValveItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Valve"; } }
        public override string Description { get { return "A device that regulates, directs, or controls the flow of fluid."; } }

    }

}