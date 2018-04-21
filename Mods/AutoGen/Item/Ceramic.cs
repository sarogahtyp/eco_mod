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

    [RequiresSkill(typeof(StoneworkingSkill), 4)]   
    public partial class CeramicRecipe : Recipe
    {
        public CeramicRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CeramicItem>(),
                new CraftingElement<IronWasteItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(StoneworkingEfficiencySkill), 5, StoneworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CopperOreItem>(typeof(StoneworkingEfficiencySkill), 10, StoneworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<IronOreItem>(typeof(StoneworkingEfficiencySkill), 1, StoneworkingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CeramicRecipe), Item.Get<CeramicItem>().UILink(), 5, typeof(StoneworkingSpeedSkill));    
            this.Initialize("Ceramic", typeof(CeramicRecipe));

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]      
    [Weight(1000)]  
    [Currency]   
    public partial class CeramicItem :
    Item
    {
        public override string FriendlyName { get { return "Ceramic"; } }
        public override string Description { get { return "Creates Even More Useful Advanced Interior Items"; } }

    }

}