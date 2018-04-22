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
	public partial class StonePickaxeRecycleRecipe : Recipe
	{
		public StonePickaxeRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
//				new CraftingElement<LogItem>(0.3f),			//	 3
//				new CraftingElement<StoneItem>(1),			//	10
				new CraftingElement<LogItem>(1),			//	10
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<StonePickaxeItem>(typeof(BasicCraftingEfficiencySkill), 16.6667f, BasicCraftingEfficiencySkill.MultiplicativeStrategy),						//	1
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(StonePickaxeRecycleRecipe), Item.Get<StonePickaxeItem>().UILink(), 0.83333f, typeof(BasicCraftingSpeedSkill));
			this.Initialize("Stone Pickaxe (Recycle)", typeof(StonePickaxeRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
		}
	}
}