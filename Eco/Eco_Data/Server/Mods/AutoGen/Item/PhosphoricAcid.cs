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
    public partial class PhosphoricAcidRecipe : Recipe
    {
        public PhosphoricAcidRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<PhosphoricAcidItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PhosphorusItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(AcidManagementEfficiencySkill), 3,AcidManagementEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CircuitRecipe), Item.Get<CircuitItem>().UILink(), 2, typeof(AcidManagementSpeedSkill));    
            this.Initialize("Phosphoric Acid", typeof(PhosphoricAcidRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]                
    [Currency]              
    public partial class PhosphoricAcidItem :
    Item    
    {
        public override string FriendlyName { get { return "Phosphoric Acid"; } }
        public override string Description { get { return ""; } }

    }

}