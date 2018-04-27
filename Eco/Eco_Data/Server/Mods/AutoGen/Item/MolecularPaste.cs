namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [MaxStackSize(500)]
    [Weight(100)]                                          
    public partial class MolecularPasteItem :
        Item            
    {
        public override string FriendlyName                     { get { return "Molecular Paste"; } }
        public override string Description                      { get { return "Unstable Paste, Ready To Be Processed"; } }
    }

    [RequiresSkill(typeof(MolecularGastronomySkill), 4)]    
    public partial class MolecularPasteRecipe : Recipe
    {
        public MolecularPasteRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<MolecularPasteItem>(5),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LiquidNitrogenItem>(typeof(MolecularGastronomyEfficiencySkill), 5, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy), 
				new CraftingElement<GoldFlakesItem>(typeof(MolecularGastronomyEfficiencySkill), 100, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<CO2CanisterItem>(typeof(MolecularGastronomyEfficiencySkill), 5, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy), 
				new CraftingElement<TransglutaminaseItem>(typeof(MolecularGastronomyEfficiencySkill), 5, MolecularGastronomyEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(MolecularPasteRecipe), Item.Get<MolecularPasteItem>().UILink(), 40, typeof(MolecularGastronomySpeedSkill)); 
            this.Initialize("Molecular Paste", typeof(MolecularPasteRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }
    }
}