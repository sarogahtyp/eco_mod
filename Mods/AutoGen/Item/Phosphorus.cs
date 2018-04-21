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

    [RequiresSkill(typeof(DistillerSkill), 2)]   
    public partial class PhosphorusRecipe : Recipe
    {
        public PhosphorusRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PhosphorusItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<LogItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),	
				new CraftingElement<BottledWaterItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PhosphorusRecipe), Item.Get<PhosphorusItem>().UILink(), 1, typeof(DistillerySpeedSkill));    
            this.Initialize("Phosphorus", typeof(PhosphorusRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [Weight(500)]                
    [Currency]              
    public partial class PhosphorusItem :
    Item    
    {
        public override string FriendlyName { get { return "Phosphorus"; } }
        public override string Description { get { return "The yellow one."; } }

    }

}