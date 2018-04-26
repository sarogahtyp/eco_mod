namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using System.ComponentModel;

    [RequiresSkill(typeof(FertilizerProductionSkill), 3)]  
    public partial class CompositeFillerRecipe : Recipe
    {
        public CompositeFillerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<CompositeFillerItem>()
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<PulpFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<FiberFillerItem>(typeof(FertilizerEfficiencySkill), 1, FertilizerEfficiencySkill.MultiplicativeStrategy), 
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(CompositeFillerRecipe), Item.Get<CompositeFillerItem>().UILink(), 0.1f, typeof(FertilizerSpeedSkill));    
            this.Initialize("Composite Filler", typeof(CompositeFillerRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject),this);
        }
    }
    
    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]  
    [Category("Tool")]
    public partial class CompositeFillerItem : FertilizerItem
    {
        public override string FriendlyName { get { return "Composite Filler"; } }
        public override string Description  { get { return ""; } }

        static CompositeFillerItem()
        {
            nutrients = new List<NutrientElement>();
            nutrients.Add(new NutrientElement("Nitrogen", 0.5f));
            nutrients.Add(new NutrientElement("Phosphorus", 0.5f));
            nutrients.Add(new NutrientElement("Potassium", 0.5f));
        }
    }
}