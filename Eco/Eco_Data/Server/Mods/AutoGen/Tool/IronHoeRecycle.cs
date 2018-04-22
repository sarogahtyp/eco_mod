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

	[RequiresSkill(typeof(MetalworkingSkill), 1)]
	public partial class IronHoeRecycleRecipe : Recipe
	{
		public IronHoeRecycleRecipe()
		{
			this.Products = new CraftingElement[] {
				new CraftingElement<BoardItem>(1),			//	10
//				new CraftingElement<IronIngotItem>(2),		//	20
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<IronHoeItem>(typeof(MetalworkingEfficiencySkill), 5, MetalworkingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(IronHoeRecycleRecipe), Item.Get<IronHoeItem>().UILink(), 0.25f, typeof(MetalworkingSpeedSkill));
			this.Initialize("Iron Hoe (Recycle)", typeof(IronHoeRecycleRecipe));
			CraftingComponent.AddRecipe(typeof(AnvilObject), this);
		}
	}
}