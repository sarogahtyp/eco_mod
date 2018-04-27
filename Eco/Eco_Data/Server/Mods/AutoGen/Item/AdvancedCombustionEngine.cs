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

    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]   
    public partial class AdvancedCombustionEngineRecipe : Recipe
    {
        public AdvancedCombustionEngineRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<AdvancedCombustionEngineItem>(),          
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 50, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PistonItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ValveItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ServoItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(IndustrialEngineeringEfficiencySkill), 10, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedCombustionEngineRecipe), Item.Get<AdvancedCombustionEngineItem>().UILink(), 10, typeof(IndustrialEngineeringSpeedSkill));    
            this.Initialize("Advanced Combustion Engine", typeof(AdvancedCombustionEngineRecipe));

            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(1000)]      
    [Currency]              
    public partial class AdvancedCombustionEngineItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Advanced Combustion Engine"; } }
        public override string Description { get { return "A more advanced version of the normal combustion engine that produces a greater output."; } }

    }

}