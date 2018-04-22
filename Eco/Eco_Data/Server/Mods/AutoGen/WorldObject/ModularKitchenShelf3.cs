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
    [RequireComponent(typeof(HousingComponent))]                          
    public partial class ModularKitchenShelf3Object : WorldObject
    {
        public override string FriendlyName { get { return "Modular Kitchen Shelf 3"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(ModularKitchenShelf3Item.HousingVal);                                



        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static ModularKitchenShelf3Object()
        {
            AddOccupancyList(typeof(ModularKitchenShelf3Object), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class ModularKitchenShelf3Item : WorldObjectItem<ModularKitchenShelf3Object>
    {
        public override string FriendlyName { get { return "Modular Kitchen Shelf 3"; } } 
        public override string Description { get { return "Part Of Modular Kitchen Set"; } }

        static ModularKitchenShelf3Item()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Kitchen",
                                                    Val = 2,
                                                    TypeForRoomLimit = "Kitchen Module",
                                                    DiminishingReturnPercent = 0.9f
                                                };}}       
    }


    [RequiresSkill(typeof(LumberWoodworkingSkill), 3)]
    public partial class ModularKitchenShelf3Recipe : Recipe
    {
        public ModularKitchenShelf3Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ModularKitchenShelf3Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberWoodworkingEfficiencySkill), 10, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(LumberWoodworkingEfficiencySkill), 20, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RivetItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<WoodPolishItem>(typeof(LumberWoodworkingEfficiencySkill), 5, LumberWoodworkingEfficiencySkill.MultiplicativeStrategy),				
            };
            SkillModifiedValue value = new SkillModifiedValue(10, LumberWoodworkingSpeedSkill.MultiplicativeStrategy, typeof(LumberWoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(ModularKitchenShelf3Recipe), Item.Get<ModularKitchenShelf3Item>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<ModularKitchenShelf3Item>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Modular Kitchen Shelf 3", typeof(ModularKitchenShelf3Recipe));
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}