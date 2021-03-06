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
    [RequireComponent(typeof(MinimapComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]            
    public partial class ConstructionPostObject : 
        WorldObject    
    {
        public override string FriendlyName { get { return "Construction Post"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Economy");                                 



            this.AddAsPOI("Marker");  
        }

        public override void Destroy()
        {
            base.Destroy();
            this.RemoveAsPOI("Marker");  
        }
       
    }

    [Serialized]
    public partial class ConstructionPostItem : WorldObjectItem<ConstructionPostObject>
    {
        public override string FriendlyName { get { return "Construction Post"; } } 
        public override string Description  { get { return  "For contruction contracts."; } }

        static ConstructionPostItem()
        {
            
        }

    }


    [RequiresSkill(typeof(BasicCraftingSkill), 1)]
    public partial class ConstructionPostRecipe : Recipe
    {
        public ConstructionPostRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ConstructionPostItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(BasicCraftingEfficiencySkill), 1, BasicCraftingEfficiencySkill.MultiplicativeStrategy),   
            };
            SkillModifiedValue value = new SkillModifiedValue(2, BasicCraftingSpeedSkill.MultiplicativeStrategy, typeof(BasicCraftingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ConstructionPostRecipe), Item.Get<ConstructionPostItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ConstructionPostItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Construction Post", typeof(ConstructionPostRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }
    }
}