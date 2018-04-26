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
    [RequireComponent(typeof(LinkComponent))]                   
    [RequireComponent(typeof(HousingComponent))]                          
    [RequireComponent(typeof(PublicStorageComponent))]                
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class StorageWardrobeObject : WorldObject
    {
        public override string FriendlyName { get { return "Old Fashion Wardrobe"; } } 


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Housing");                                 
            this.GetComponent<HousingComponent>().Set(StorageWardrobeItem.HousingVal);
            this.GetComponent<LinkComponent>().Initialize(10);

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(32);
            storage.Storage.AddRestriction(new NotCarriedRestriction()); // can't store block or large items


        }

        public override void Destroy()
        {
            base.Destroy();
        }
        static StorageWardrobeObject()
        {
            AddOccupancyList(typeof(StorageWardrobeObject), new BlockOccupancy(Vector3i.Zero, typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(StorageWardrobeObject), new BlockOccupancy(new Vector3i(0, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(StorageWardrobeObject), new BlockOccupancy(new Vector3i(0, 2, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(StorageWardrobeObject), new BlockOccupancy(new Vector3i(-1, 0, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(StorageWardrobeObject), new BlockOccupancy(new Vector3i(-1, 1, 0), typeof(WorldObjectBlock)));
            AddOccupancyList(typeof(StorageWardrobeObject), new BlockOccupancy(new Vector3i(-1, 2, 0), typeof(WorldObjectBlock)));
        }
    }

    [Serialized]
    public partial class StorageWardrobeItem : WorldObjectItem<StorageWardrobeObject>
    {
        public override string FriendlyName { get { return "Old Fashion Wardrobe"; } } 
        public override string Description { get { return "A Smelly Wardrobe."; } }

        static StorageWardrobeItem()
        {
            
        }
        
        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue() 
                                                {
                                                    Category = "Bedroom",
                                                    Val = 1,
                                                    TypeForRoomLimit = "Cabinet",
                                                    DiminishingReturnPercent = 0.75f
                                                };}}       
    }


    [RequiresSkill(typeof(WoodworkingSkill), 4)]
    public partial class StorageWardrobeRecipe : Recipe
    {
        public StorageWardrobeRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<StorageWardrobeItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 10, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 30, WoodworkingEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(10, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.Do("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(StorageWardrobeRecipe), Item.Get<StorageWardrobeItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<StorageWardrobeItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Old Fashion Wardrobe", typeof(StorageWardrobeRecipe));
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }
    }
}