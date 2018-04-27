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

	[RequiresSkill(typeof(PetrolRefiningSkill), 4)]
	public class TailingsOilRecipe : Recipe
	{
		public TailingsOilRecipe()
		{
			this.Products = new CraftingElement[]
			{
				new CraftingElement<TailingsItem>(1),
				new CraftingElement<DirtItem>(4),
				new CraftingElement<StoneItem>(2),
				new CraftingElement<PhosphateFertilizerItem>(1),
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<TailingsItem>(typeof(PetrolRefiningEfficiencySkill), 15, PetrolRefiningEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(IronIngotRecipe), Item.Get<DirtItem>().UILink(), 2, typeof(BasicSmeltingSpeedSkill));
			this.Initialize("TailingsOil", typeof(TailingsOilRecipe));
			CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
		}
	}
}