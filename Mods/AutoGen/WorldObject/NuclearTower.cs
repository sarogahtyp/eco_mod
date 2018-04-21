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
    public partial class NuclearTowerItem : WorldObjectItem<NuclearTowerObject>
    {
        public override string FriendlyName { get { return "Nuclear Tower"; } }
        public override string Description { get { return "Part of Nuclear Plant"; } }

        static NuclearTowerItem()
        {

        }

        [TooltipChildren]
        public static HousingValue HousingVal
        {
            get
            {
                return new HousingValue()
                {
                    Category = "Industrial",
                    Val = 0,
                    TypeForRoomLimit = "",
                    DiminishingReturnPercent = 0
                };
            }
        }
    }


    [RequiresSkill(typeof(IndustrialEngineeringSkill), 4)]
    public partial class NuclearTowerRecipe : Recipe
    {
        public NuclearTowerRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<NuclearTowerItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<ConcreteItem>(typeof(IndustrialEngineeringEfficiencySkill), 200, IndustrialEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<SteelItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(ElectronicEngineeringEfficiencySkill), 20, ElectronicEngineeringEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(240, ElectronicEngineeringSpeedSkill.MultiplicativeStrategy, typeof(ElectronicEngineeringSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(NuclearTowerRecipe), Item.Get<NuclearTowerItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<NuclearTowerItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Nuclear Tower", typeof(NuclearTowerRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}