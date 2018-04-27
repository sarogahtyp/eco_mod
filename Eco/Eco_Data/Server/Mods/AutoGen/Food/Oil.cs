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
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [MaxStackSize(500)]
    [Weight(100)]                                          
    [Fuel(4000)]                                              
    public partial class OilItem :
        FoodItem            
    {
        public override string FriendlyName                     { get { return "Oil"; } }
        public override string FriendlyNamePlural               { get { return "Oil"; } } 
        public override string Description                      { get { return "A plant fat extracted for use in cooking."; } }

        private static Nutrients nutrition = new Nutrients()    { Carbs = 0, Fat = 15, Protein = 0, Vitamins = 0};
        public override float Calories                          { get { return 120; } }
        public override Nutrients Nutrition                     { get { return nutrition; } }
    }

    [RequiresSkill(typeof(MillProcessingSkill), 2)]    
    public partial class OilRecipe : Recipe
    {
        public OilRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),
               
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CerealGermItem>(typeof(MillProcessingEfficiencySkill), 30, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),	
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill)); 
            this.Initialize("Oil", typeof(OilRecipe));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
	public partial class OilRecipe2 : Recipe
    {
        public OilRecipe2()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<HuckleberrySeedItem>(typeof(MillProcessingEfficiencySkill), 100, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe2), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill));
            this.Initialize("Oil from Huckberry Seeds", typeof(OilRecipe2));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
    public partial class OilRecipe3 : Recipe
    {
        public OilRecipe3()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<WheatSeedItem>(typeof(MillProcessingEfficiencySkill), 100, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe3), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill));
            this.Initialize("Oil from Wheat Seeds", typeof(OilRecipe3));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
    public partial class OilRecipe4 : Recipe
    {
        public OilRecipe4()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<CornSeedItem>(typeof(MillProcessingEfficiencySkill), 100, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe4), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill));
            this.Initialize("Oil from Corn Seeds", typeof(OilRecipe4));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
	public partial class OilRecipe6 : Recipe
    {
        public OilRecipe6()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<FernSporeItem>(typeof(MillProcessingEfficiencySkill), 100, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe2), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill));
            this.Initialize("Oil from Fern Spore", typeof(OilRecipe2));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
	public partial class OilRecipe7 : Recipe
    {
        public OilRecipe7()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<TomatoSeedItem>(typeof(MillProcessingEfficiencySkill), 100, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe2), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill));
            this.Initialize("Oil from Tomato Seeds", typeof(OilRecipe2));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
    public partial class OilRecipe5 : Recipe
    {
        public OilRecipe5()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<OilItem>(),

            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<BeetSeedItem>(typeof(MillProcessingEfficiencySkill), 100, MillProcessingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<BottleItem>(typeof(MillProcessingEfficiencySkill), 1, MillProcessingEfficiencySkill.MultiplicativeStrategy),
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(OilRecipe5), Item.Get<OilItem>().UILink(), 5, typeof(MillProcessingSpeedSkill));
            this.Initialize("Oil from Beet Seeds", typeof(OilRecipe5));
            CraftingComponent.AddRecipe(typeof(MillObject), this);
        }
    }
}