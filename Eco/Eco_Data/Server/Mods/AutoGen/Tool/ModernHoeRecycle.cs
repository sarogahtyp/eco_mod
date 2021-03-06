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
	public partial class ModernHoeRecycleRecipe : Recipe
	{
		public ModernHoeRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<FiberglassItem>(2),		//	20
//				new CraftingElement<SteelItem>(3),			//	30
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<ModernHoeItem>(typeof(SteelworkingEfficiencySkill), 5, SteelworkingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(ModernHoeRecycleRecipe), Item.Get<ModernHoeItem>().UILink(), 0.25f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Modern Hoe (Recycle)", typeof(ModernHoeRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(FactoryObject), this);
		}
	}
}