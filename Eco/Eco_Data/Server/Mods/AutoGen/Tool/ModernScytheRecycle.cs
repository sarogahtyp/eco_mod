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
	public partial class ModernScytheRecycleRecipe : Recipe
	{
		public ModernScytheRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<FiberglassItem>(2),		//	20
//				new CraftingElement<SteelItem>(3),			//	30
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<ModernScytheItem>(typeof(SteelworkingEfficiencySkill), 5, SteelworkingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(ModernScytheRecycleRecipe), Item.Get<ModernScytheItem>().UILink(), 0.25f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Modern Scythe (Recycle)", typeof(ModernScytheRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(FactoryObject), this);
		}
	}
}