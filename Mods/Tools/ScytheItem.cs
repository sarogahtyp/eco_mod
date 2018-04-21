// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
	using System.Text;
    using Core.Utils;
	using Eco.Core.Localization;
	using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Plants;
    using Eco.Gameplay.Systems.TextLinks;
	using Eco.Shared.Math;
	using Eco.Simulation.Types;
    using Eco.Shared.Items;
	using Eco.Shared.Utils;
    using Eco.Simulation;
    using Eco.World;
	using Kirthos.Mods;

    [Category("Hidden")]
    [Mower]
    public partial class ScytheItem : ToolItem
    {
        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(10, typeof(FarmingSkill), typeof(ScytheItem), new ScytheItem().UILink());
        static ScytheItem() { }

        public override IDynamicValue CaloriesBurn            { get { return caloriesBurn; } }

        public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.Harvest; } }
        public override string LeftActionDescription          { get { return "Reap"; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (!context.HasBlock || !context.Block.Is<Reapable>())
                return InteractResult.NoOp;
            
            var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value);
            if (plant != null && plant is IHarvestable)
            {
                if (plant.Dead)
                {
                    EcoSim.PlantSim.DestroyPlant(plant, DeathType.Harvesting);
                    return InteractResult.Success;
                }
                else
                {
                    Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
                    if (result.Success)
                    {
                        this.BurnCalories(context.Player);
                        context.Player.SpawnBlockEffect(context.BlockPosition.Value, context.Block.GetType(), BlockEffect.Harvest);
                    }

                    return (InteractResult)result;
                }
            }
            else
                return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false);
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<Reapable>(block);
			
        }
        public override InteractResult OnActRight(InteractionContext context)
        {
            if (context.HasBlock)
            {
				var plant = EcoSim.PlantSim.GetPlant(context.BlockPosition.Value);
				var block = World.GetBlock(context.BlockPosition.Value);
				if (plant != null && plant is IHarvestable)
                
			{
					
					if (block is CornBlock )
					{
						Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
							InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
							changes.AddItems<CornItem>((4)  + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
							changes.AddItems<CornSeedItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
							PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
							return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
						}
						else 
						return InteractResult.NoOp;
					}	
					
			
			
			
                else if (block is TomatoesBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<TomatoItem>(4 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
					changes.AddItems<TomatoSeedItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
						else 
						return InteractResult.NoOp;
                }
                    
			
                else if (block is FireweedBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<FireweedShootsItem>(5 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(TundraTravellerSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
						else 
						return InteractResult.NoOp;
                }
                    
			
                else if (block is WheatBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<WheatItem>(5 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
					changes.AddItems<WheatSeedItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
						}
					else 
						return InteractResult.NoOp;
			   }
                    
			
                else if (block is BeansBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<BeansItem>(6 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(ForestForagerSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
						}
					else 
						return InteractResult.NoOp;
                }
                    
			
                else if (block is HuckleberryBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<HuckleberriesItem>(5 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(ForestForagerSkill)));
					changes.AddItems<HuckleberrySeedItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(ForestForagerSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
					else 
						return InteractResult.NoOp;
                }
				else if (block is BeetsBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<BeetItem>(3 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
					changes.AddItems<BeetSeedItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
						}
						else 
						return InteractResult.NoOp;
                }
				else if (block is RiceBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<RiceItem>(3 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
						else 
						return InteractResult.NoOp;
                }
				else if (block is KelpBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<KelpItem>(1);					
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
						else 
						return InteractResult.NoOp;
                }
				else if (block is PricklyPearBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<PricklyPearFruitItem>(3 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
					changes.AddItems<PricklyPearSeedItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
						else 
						return InteractResult.NoOp;
                }
				else if (block is FernBlock)
                {
					Result result = (plant as IHarvestable).TryHarvest(context.Player, true);
						if (result.Success)
						{
                    InventoryChangeSet changes = new InventoryChangeSet(context.Player.User.Inventory, context.Player.User);
                    changes.AddItems<FiddleheadsItem>(3 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
					changes.AddItems<FernSporeItem>(1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(GrasslandGathererSkill)));
                    PlantUtils.GetPlantBlockAroundPoint(context.Player.User, context.BlockPosition.Value, 1 + SkillsUtil.GetSkillLevel(context.Player.User, typeof(FarmingRadiusSkill)));
                    return (InteractResult)this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 3, null, changes);
					}
						else 
						return InteractResult.NoOp;
                }
                    
			}
			return InteractResult.NoOp;
		}
		return InteractResult.NoOp;
	}
}}	