namespace Eco.Mods.TechTree
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using Eco.Gameplay.Blocks;
	using Eco.Gameplay.Components;
	using Eco.Gameplay.DynamicValues;
	using Eco.Gameplay.Items;
	using Eco.Gameplay.Objects;
	using Eco.Gameplay.Players;
	using Eco.Gameplay.Skills;
	using Eco.Gameplay.Systems.TextLinks;
	using Eco.Shared.Localization;
	using Eco.Shared.Serialization;
	using Eco.Shared.Utils;
	using Eco.World;
	using Eco.World.Blocks;
	using Eco.Gameplay.Pipes;

	[RequiresSkill(typeof(CastingSkill), 3)]
	public partial class UraniumRecipe : Recipe
	{
		public UraniumRecipe()
		{
			this.Products = new CraftingElement[]
			{
				new CraftingElement<UraniumItem>(),
				new CraftingElement<TailingsItem>(4),
			};
			this.Ingredients = new CraftingElement[]
			{
				new CraftingElement<CopperIngotItem>(typeof(CastingEfficiencySkill), 5, CastingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<FiberglassItem>(typeof(CastingEfficiencySkill), 5, CastingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<MolecularPasteItem>(typeof(CastingEfficiencySkill), 5, CastingEfficiencySkill.MultiplicativeStrategy),
			};
			this.CraftMinutes = CreateCraftTimeValue(typeof(UraniumRecipe), Item.Get<UraniumItem>().UILink(), 30, typeof(CastingSpeedSkill));
			this.Initialize("Uranium", typeof(UraniumRecipe));

			CraftingComponent.AddRecipe(typeof(BlastFurnaceObject), this);
		}
	}

	[Serialized]
	[MaxStackSize(500)]
	[Weight(2000)]
	[Fuel(500000)]
	public partial class UraniumItem :
	Item
	{
		public override string FriendlyName { get { return "Uranium"; } }
		public override string Description { get { return "Food for your Nuclear Plant"; } }
	}

}