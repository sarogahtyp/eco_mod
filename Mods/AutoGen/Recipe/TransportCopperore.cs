namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;

    [RequiresSkill(typeof(BasicCraftingSkill), 2)] 
    public class TransportCopperOreRecipe : Recipe
    {
        public TransportCopperOreRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<CopperOreItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CopperOreItem>(1), 
            };
            this.Initialize("Transport CopperOre", typeof(TransportCopperOreRecipe));
            this.CraftMinutes = new ConstantValue(0.1f);
            CraftingComponent.AddRecipe(typeof(LogisticRobotObject), this);
        }
    }
}