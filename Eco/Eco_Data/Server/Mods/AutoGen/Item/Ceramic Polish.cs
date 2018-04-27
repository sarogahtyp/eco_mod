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

    [RequiresSkill(typeof(AcidManagementSkill), 2)]   
    public partial class CeramicPolishRecipe : Recipe
    {
        public CeramicPolishRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CeramicPolishItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PhosphoricAcidItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<PotashItem>(typeof(AcidManagementEfficiencySkill), 1, AcidManagementEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SulfuricAcidItem>(typeof(AcidManagementEfficiencySkill), 5, AcidManagementEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CeramicPolishRecipe), Item.Get<CeramicPolishItem>().UILink(), 3, typeof(AcidManagementSpeedSkill));    
            this.Initialize("Ceramic Polish", typeof(CeramicPolishRecipe));

            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }

    [Serialized]
	[MaxStackSize(500)]	//	[MaxStackSize(20)]      
    [Weight(10000)]  
    [Currency]   
    public partial class CeramicPolishItem :
    Item
    {
        public override string FriendlyName { get { return "Ceramic Polish"; } }
        public override string Description { get { return "Let it shine"; } }

    }

}