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
    public class TransportGlassRecipe : Recipe
    {
        public TransportGlassRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<GlassItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(1), 
            };
            this.Initialize("Transport Glass ", typeof(TransportGlassRecipe));
            this.CraftMinutes = new ConstantValue(0.025f);
            CraftingComponent.AddRecipe(typeof(LogisticRobotObject), this);
        }
    }
}