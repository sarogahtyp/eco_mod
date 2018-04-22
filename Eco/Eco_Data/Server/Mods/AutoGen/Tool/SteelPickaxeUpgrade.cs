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
	public partial class SteelPickaxeUpgradeRecipe : Recipe
	{
		public SteelPickaxeUpgradeRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<SteelPickaxeItem>(1),
//				new CraftingElement<IronIngotItem>(2),		//	20
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<IronPickaxeItem>(typeof(MetalworkingEfficiencySkill), 5, MetalworkingEfficiencySkill.MultiplicativeStrategy),
//				new CraftingElement<BoardItem>(typeof(SteelworkingEfficiencySkill), 10, SteelworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(SteelPickaxeUpgradeRecipe), Item.Get<SteelPickaxeItem>().UILink(), 0.75f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Steel Pickaxe (Upgrade)", typeof(SteelPickaxeUpgradeRecipe));
			CraftingComponent.AddRecipe(typeof(AnvilObject), this);
		}
	}
}