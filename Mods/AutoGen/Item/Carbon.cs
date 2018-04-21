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
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(DistillerSkill), 1)]   
    public partial class CarbonRecipe : Recipe
    {
        public CarbonRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CarbonItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CharcoalItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(DistilleryEfficiencySkill), 5, DistilleryEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CarbonRecipe), Item.Get<CarbonItem>().UILink(), 1, typeof(DistillerySpeedSkill));    
            this.Initialize("Carbon", typeof(CarbonRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [Weight(500)]                
    [Currency]              
    public partial class CarbonItem :
    Item    
    {
        public override string FriendlyName { get { return "Carbon"; } }
        public override string Description { get { return "Pure Carbon."; } }

    }

}