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

    [RequiresSkill(typeof(AcidManagementSkill), 1)]   
    public partial class SulfuricAcidRecipe : Recipe
    {
        public SulfuricAcidRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SulfuricAcidItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SulfurItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottledWaterItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(SulfuricAcidRecipe), Item.Get<SulfuricAcidItem>().UILink(), 1, typeof(AcidManagementSpeedSkill));    
            this.Initialize("Sulfuric Acid", typeof(SulfuricAcidRecipe));

            CraftingComponent.AddRecipe(typeof(DistilleryObject), this);
        }
    }


    [Serialized]
    [Weight(500)]                
    [Currency]              
    public partial class SulfuricAcidItem :
    Item    
    {
        public override string FriendlyName { get { return "Sulfuric Acid"; } }
        public override string Description { get { return "Pure."; } }

    }

}