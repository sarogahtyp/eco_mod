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

	[RequiresSkill(typeof(SteelworkingSkill), 3)]
	public partial class ModernHoeUpgradeRecipe : Recipe
	{
		public ModernHoeUpgradeRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<ModernHoeItem>(1),
				new CraftingElement<BoardItem>(1),			//	10
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<SteelHoeItem>(typeof(SteelworkingEfficiencySkill), 5, SteelworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<FiberglassItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),	//	s=20 m=30 >> sm=10 + 20
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(ModernHoeUpgradeRecipe), Item.Get<ModernHoeItem>().UILink(), 0.75f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Modern Hoe (Upgrade)", typeof(ModernHoeUpgradeRecipe));
			CraftingComponent.AddRecipe(typeof(FactoryObject), this);
		}
	}
}