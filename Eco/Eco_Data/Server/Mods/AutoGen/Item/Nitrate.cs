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
    public partial class NitrateRecipe : Recipe
    {
        public NitrateRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<NitrateItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ScrapMeatItem>(typeof(DistilleryEfficiencySkill), 2, DistilleryEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(DistilleryEfficiencySkill), 3, DistilleryEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(NitrateRecipe), Item.Get<NitrateItem>().UILink(), 1, typeof(DistillerySpeedSkill));    
            this.Initialize("Nitrate", typeof(NitrateRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]                
    [Currency]              
    public partial class NitrateItem :
    Item    
    {
        public override string FriendlyName { get { return "Nitrate"; } }
        public override string Description { get { return "You are not gonna eat that?."; } }

    }

}