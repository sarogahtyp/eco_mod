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

    [RequiresSkill(typeof(BasicCraftingSkill), 1)]   
    public partial class BottledWaterRecipe : Recipe
    {
        public BottledWaterRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<BottledWaterItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BottleItem>(typeof(BasicCraftingEfficiencySkill), 1, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(BottledWaterRecipe), Item.Get<BottledWaterItem>().UILink(), 1, typeof(BasicCraftingSpeedSkill));    
            this.Initialize("Bottled Water", typeof(BottledWaterRecipe));

            CraftingComponent.AddRecipe(typeof(WaterPumpObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]                
    [Currency]              
    public partial class BottledWaterItem :
    Item    
    {
        public override string FriendlyName { get { return "Bottled Water"; } }
        public override string Description { get { return "Fresh Water."; } }

    }

}