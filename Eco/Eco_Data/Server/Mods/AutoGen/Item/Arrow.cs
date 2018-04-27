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

    [RequiresSkill(typeof(BasicCraftingSkill), 3)]   
    public partial class ArrowRecipe : Recipe
    {
        public ArrowRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ArrowItem>(4),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 1, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(ArrowRecipe), Item.Get<ArrowItem>().UILink(), 0.1f, typeof(BasicCraftingSpeedSkill));    
            this.Initialize("Arrow", typeof(ArrowRecipe));

            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(10)]      
    [Fuel(500)]          
    [Currency]              
    public partial class ArrowItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Arrow"; } }
        public override string Description { get { return "Use with the bow to hunt for food (or amaze your friends by shooting apples off of their heads)."; } }

    }

}