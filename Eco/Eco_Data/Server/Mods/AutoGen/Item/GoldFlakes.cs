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

    [RequiresSkill(typeof(ElectronicEngineeringSkill), 1)]   
    public partial class GoldFlakesRecipe : Recipe
    {
        public GoldFlakesRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GoldFlakesItem>(4),  
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GoldIngotItem>(typeof(ElectronicEngineeringEfficiencySkill), 5, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GoldFlakesRecipe), Item.Get<GoldFlakesItem>().UILink(), 2, typeof(ElectronicEngineeringSpeedSkill));    
            this.Initialize("Gold Flakes", typeof(GoldFlakesRecipe));

            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }
    }


    [Serialized]
    [MaxStackSize(500)]
    [Weight(500)]      
    [Currency]              
    public partial class GoldFlakesItem :
    Item                                     
    {
        public override string FriendlyName { get { return "Gold Flakes"; } }
        public override string FriendlyNamePlural { get { return "Gold Flakes"; } } 
        public override string Description { get { return "A highly efficient conductor for delicate electronics."; } }

    }

}