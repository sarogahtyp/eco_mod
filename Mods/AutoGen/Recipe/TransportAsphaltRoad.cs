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
    public class TransportAsphaltRoadRecipe : Recipe
    {
        public TransportAsphaltRoadRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<AsphaltRoadItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<AsphaltRoadItem>(1), 
            };
            this.Initialize("Transport Asphalt Road", typeof(TransportAsphaltRoadRecipe));
            this.CraftMinutes = new ConstantValue(0.1f);
            CraftingComponent.AddRecipe(typeof(LogisticRobotObject), this);
        }
    }
}