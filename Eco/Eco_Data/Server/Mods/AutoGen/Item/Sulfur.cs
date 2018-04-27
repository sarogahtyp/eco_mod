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

    [RequiresSkill(typeof(DistillerSkill), 4)]   
    public partial class SulfurRecipe : Recipe
    {
        public SulfurRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SulfurItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SulfurRecipe), Item.Get<SulfurItem>().UILink(), 1, typeof(DistillerySpeedSkill));    
            this.Initialize("Sulfur", typeof(CarbonRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]                
    [Currency]              
    public partial class SulfurItem :
    Item    
    {
        public override string FriendlyName { get { return "Sulfur"; } }
        public override string Description { get { return "Sulfur."; } }

    }

}