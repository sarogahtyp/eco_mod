namespace Eco.Mods.TechTree
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
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
	using Eco.Gameplay.Pipes;

	[RequiresSkill(typeof(BasicCraftingSkill), 0)]
	public partial class WoodenHoeRecycleRecipe : Recipe
	{
		public WoodenHoeRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<LogItem>(1),			//	10
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<WoodenHoeItem>(typeof(BasicCraftingEfficiencySkill), 5, BasicCraftingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenHoeRecycleRecipe), Item.Get<WoodenHoeItem>().UILink(), 0.25f, typeof(BasicCraftingSpeedSkill));
			this.Initialize("Wooden Hoe (Recycle)", typeof(WoodenHoeRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
		}
	}
}