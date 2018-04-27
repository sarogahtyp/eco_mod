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

    [RequiresSkill(typeof(CharBurnerSkill), 1)]   
    public partial class CharcoalRecipe : Recipe
    {
        public CharcoalRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(CoalProcessingEfficiencySkill), 2, CoalProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPulpItem>(typeof(CoalProcessingEfficiencySkill), 15, CoalProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CharcoalRecipe), Item.Get<CharcoalItem>().UILink(), 1, typeof(SteelworkingSpeedSkill));    
            this.Initialize("Charcoal", typeof(CharcoalRecipe));

            CraftingComponent.AddRecipe(typeof(CampfireObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(1000)]      
    [Fuel(20000)]          
    [Currency]              
    public partial class CharcoalItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Charcoal"; } }
        public override string Description { get { return "A black residue, consisting of carbon and any remaining ash."; } }

    }

}