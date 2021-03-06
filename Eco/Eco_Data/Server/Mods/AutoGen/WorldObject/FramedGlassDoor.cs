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
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class FramedGlassDoorObject : 
        DoorObject 
    {
        public override string FriendlyName { get { return "Framed Glass Door"; } } 


        protected override void Initialize()
        {



        }

        public override void Destroy()
        {
            base.Destroy();
        }
       
    }

    [Serialized]
    public partial class FramedGlassDoorItem : WorldObjectItem<FramedGlassDoorObject>
    {
        public override string FriendlyName { get { return "Framed Glass Door"; } } 
        public override string Description  { get { return  "A beautiful glass door made of steel and glass."; } }

        static FramedGlassDoorItem()
        {
            
        }

    }


    [RequiresSkill(typeof(GlassworkingSkill), 1)]
    public partial class FramedGlassDoorRecipe : Recipe
    {
        public FramedGlassDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FramedGlassDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FramedGlassItem>(typeof(GlassProductionEfficiencySkill), 10, GlassProductionEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(20, GlassProductionSpeedSkill.MultiplicativeStrategy, typeof(GlassProductionSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FramedGlassDoorRecipe), Item.Get<FramedGlassDoorItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FramedGlassDoorItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Framed Glass Door", typeof(FramedGlassDoorRecipe));
            CraftingComponent.AddRecipe(typeof(FactoryObject), this);
        }
    }
}