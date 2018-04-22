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

    [RequiresSkill(typeof(HomeCookingSkill), 3)] 
    public class ExoticFruitSaladRecipe : Recipe
    {
        public ExoticFruitSaladRecipe()
        {
            this.Products = new CraftingElement[]
            {
               new CraftingElement<FruitSaladItem>(1),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PricklyPearFruitItem>(typeof(HomeCookingEfficiencySkill), 15, HomeCookingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<TomatoItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy), 
            };
            this.Initialize("Exotic Fruit Salad", typeof(ExoticFruitSaladRecipe));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ExoticFruitSaladRecipe), this.UILink(), 2, typeof(HomeCookingSpeedSkill));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}