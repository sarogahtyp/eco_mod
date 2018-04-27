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

    [RequiresSkill(typeof(GlassworkingSkill), 1)]   
    public partial class BottleRecipe : Recipe
    {
        public BottleRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BottleItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(GlassProductionEfficiencySkill), 1, GlassProductionEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BottleRecipe), Item.Get<BottleItem>().UILink(), 1, typeof(GlassProductionSpeedSkill));    
            this.Initialize("Bottle", typeof(BottleRecipe));

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(100)]                
    [Currency]              
    public partial class BottleItem :
    Item    
    {
        public override string FriendlyName { get { return "Bottle"; } }
        public override string Description { get { return "Just a empty bottle."; } }

    }

}