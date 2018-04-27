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

    [RequiresSkill(typeof(AcidManagementSkill), 2)]   
    public partial class PotashRecipe : Recipe
    {
        public PotashRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PotashItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PottassiumItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(PotashRecipe), Item.Get<PotashItem>().UILink(), 1, typeof(AcidManagementSpeedSkill));    
            this.Initialize("Potash", typeof(PotashRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]                
    [Currency]              
    public partial class PotashItem :
    Item    
    {
        public override string FriendlyName { get { return "Potash"; } }
        public override string Description { get { return "Just Potash."; } }

    }

}