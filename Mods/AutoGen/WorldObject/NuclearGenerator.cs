namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    

    [Serialized]
    public partial class NuclearGeneratorItem : WorldObjectItem<NuclearGeneratorObject>
    {
        public override string FriendlyName { get { return "Nuclear Generator"; } } 
        public override string Description { get { return "Nuclear Plant Main Part"; } }

        static NuclearGeneratorItem()
        {
            
        }
        
    }


    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]
    public partial class NuclearGeneratorRecipe : Recipe
    {
        public NuclearGeneratorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<NuclearGeneratorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<SteelItem>(typeof(IndustrialEngineeringEfficiencySkill), 50, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(IndustrialEngineeringEfficiencySkill), 30, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<ConcreteItem>(typeof(IndustrialEngineeringEfficiencySkill), 40, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(720, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(NuclearGeneratorRecipe), Item.Get<NuclearGeneratorItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<NuclearGeneratorItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Nuclear Generator", typeof(NuclearGeneratorRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}