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

	[RequiresSkill(typeof(SteelworkingSkill), 4)]
	public partial class ModernHammerUpgradeRecipe : Recipe
	{
		public ModernHammerUpgradeRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<ModernHammerItem>(1),
				new CraftingElement<BoardItem>(1),			//	10
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<SteelHammerItem>(typeof(SteelworkingEfficiencySkill), 5, SteelworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<FiberglassItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<SteelItem>(typeof(SteelworkingEfficiencySkill), 20, SteelworkingEfficiencySkill.MultiplicativeStrategy),	//	s=20 m=30 >> sm=10 + 20
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(ModernHammerUpgradeRecipe), Item.Get<ModernHammerItem>().UILink(), 0.75f, typeof(SteelworkingSpeedSkill));
			this.Initialize("Modern Hammer (Upgrade)", typeof(ModernHammerUpgradeRecipe));
			CraftingComponent.AddRecipe(typeof(FactoryObject), this);
		}
	}
}