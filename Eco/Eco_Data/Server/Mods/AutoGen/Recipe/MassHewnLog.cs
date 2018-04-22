namespace Eco.Mods.TechTree
{
	using System;
	using System.Collections.Generic;
	using Eco.Gameplay.Components;
	using Eco.Gameplay.DynamicValues;
	using Eco.Gameplay.Items;
	using Eco.Gameplay.Skills;
	using Eco.Shared.Utils;
	using Eco.World;
	using Eco.World.Blocks;
	using Gameplay.Systems.TextLinks;

	[RequiresSkill(typeof(HewingSkill), 1)]
	public class MassHewnLogRecipe : Recipe
	{
		public MassHewnLogRecipe()
		{
			this.Products = new CraftingElement[]
			{
			   new CraftingElement<HewnLogItem>(1),
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<LogItem>(typeof(HewnLogProcessingEfficiencySkill), 2, HewnLogProcessingEfficiencySkill.MultiplicativeStrategy),
			};
			this.Initialize("Mass Hewn Log", typeof(MassHewnLogRecipe));
			this.CraftMinutes = CreateCraftTimeValue(typeof(MassHewnLogRecipe), this.UILink(), 0.05f, typeof(HewnLogProcessingSpeedSkill));
			CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
		}
	}
}