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
	public partial class SteelHammerRecycleRecipe : Recipe
	{
		public SteelHammerRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<BoardItem>(1),			//	10
//				new CraftingElement<SteelItem>(2),			//	20
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<SteelHammerItem>(typeof(SteelworkingEfficiencySkill), 5, SteelworkingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(SteelHammerRecycleRecipe), Item.Get<SteelHammerItem>().UILink(), 0.25f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Steel Hammer (Recycle)", typeof(SteelHammerRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(AnvilObject), this);
		}
	}
}