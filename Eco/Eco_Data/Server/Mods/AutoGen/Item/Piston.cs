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
    public partial class PistonRecipe : Recipe
    {
        public PistonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PistonItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronPipeItem>(typeof(MechanicsComponentsEfficiencySkill), 5, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MechanicsComponentsEfficiencySkill), 10, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<OilItem>(typeof(MechanicsComponentsEfficiencySkill), 5, MechanicsComponentsEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PistonRecipe), Item.Get<PistonItem>().UILink(), 2, typeof(MechanicsComponentsSpeedSkill));    
            this.Initialize("Piston", typeof(PistonRecipe));

            CraftingComponent.AddRecipe(typeof(MachineShopObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(1000)]      
    [Currency]              
    public partial class PistonItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Piston"; } }
        public override string Description { get { return "A moving component that transfers force. Can also function as a valve occasionally."; } }

    }

}