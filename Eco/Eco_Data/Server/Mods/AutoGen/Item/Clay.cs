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
    public partial class ClayRecipe : Recipe
    {
        public ClayRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ClayItem>(),
                };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SandItem>(typeof(StoneworkingEfficiencySkill), 5, StoneworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CopperOreItem>(typeof(StoneworkingEfficiencySkill), 5, StoneworkingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ClayRecipe), Item.Get<ClayItem>().UILink(), 3, typeof(StoneworkingSpeedSkill));    
            this.Initialize("Clay", typeof(ClayRecipe));

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }

    [Serialized]    
    [Weight(1000)]  
    [Currency]   
    public partial class ClayItem :
    Item
    {
        public override string FriendlyName { get { return "Clay"; } }
        public override string Description { get { return "Creates Useful Advanced Interior Items"; } }

    }

}