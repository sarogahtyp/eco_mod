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

    [RequiresSkill(typeof(BasicSmeltingSkill), 1)]   
    public partial class CopperIngotRecipe : Recipe
    {
        public CopperIngotRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CopperIngotItem>(),          
            new CraftingElement<TailingsItem>(2),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperOreItem>(typeof(BasicSmeltingEfficiencySkill), 5, BasicSmeltingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CopperIngotRecipe), Item.Get<CopperIngotItem>().UILink(), 2, typeof(BasicSmeltingSpeedSkill));    
            this.Initialize("Copper Ingot", typeof(CopperIngotRecipe));

            CraftingComponent.AddRecipe(typeof(BloomeryObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(4000)]      
    [Currency]              
    public partial class CopperIngotItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Copper Ingot"; } }
        public override string Description { get { return "A hefty block of copper."; } }

    }

}