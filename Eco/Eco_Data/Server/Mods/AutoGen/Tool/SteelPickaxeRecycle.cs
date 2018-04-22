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

	[RequiresSkill(typeof(SteelworkingSkill), 1)]
	public partial class SteelPickaxeRecycleRecipe : Recipe
	{
		public SteelPickaxeRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<BoardItem>(1),			//	10
//				new CraftingElement<SteelItem>(2),			//	20
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<SteelPickaxeItem>(typeof(SteelworkingEfficiencySkill), 5, SteelworkingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(SteelPickaxeRecycleRecipe), Item.Get<SteelPickaxeItem>().UILink(), 0.25f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Steel Pickaxe (Recycle)", typeof(SteelPickaxeRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(AnvilObject), this);
		}
	}
}