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

    [RequiresSkill(typeof(PetrolRefiningSkill), 1)]   
    public partial class PrinterBoxRecipe : Recipe
    {
        public PrinterBoxRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PrinterBoxItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PlasticItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<EpoxyItem>(typeof(PetrolRefiningEfficiencySkill), 5, PetrolRefiningEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PrinterBoxRecipe), Item.Get<PrinterBoxItem>().UILink(), 10, typeof(PetrolRefiningSpeedSkill));    
            this.Initialize("Printer Box", typeof(PrinterBoxRecipe));

            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }

    [Serialized]
    [MaxStackSize(500)]
    [Weight(4000)]      
    [Currency]
    public partial class PrinterBoxItem :
    Item
    {
        public override string FriendlyName { get { return "Printer Box"; } }
        public override string Description { get { return "Blank Box For 3D Printer"; } }

    }

}