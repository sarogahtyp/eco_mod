// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
namespace Eco.Mods.TechTree
{
    using System;
    using System.ComponentModel;
    using Core.Utils;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Objects;
    using Kirthos.Mods;

    [Category("Hidden")]
    public partial class PickaxeItem : ToolItem
    {
        private static SkillModifiedValue caloriesBurn = CreateCalorieValue(20, typeof(MiningSkill), typeof(PickaxeItem), new PickaxeItem().UILink());
        static PickaxeItem() { }

        public override IDynamicValue CaloriesBurn            { get { return caloriesBurn; } }

        public override ClientPredictedBlockAction LeftAction { get { return ClientPredictedBlockAction.DestroyBlock; } }
        public override string LeftActionDescription          { get { return "Mine"; } }

        private static IDynamicValue skilledRepairCost = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost { get { return skilledRepairCost; } }

        public override InteractResult OnActLeft(InteractionContext context)
        {
            if (context.HasBlock && context.Block.Is<Minable>())
            {
                Result result = this.PlayerDeleteBlock(context.BlockPosition.Value, context.Player, false, 1);
                if (result.Success)
                    if (RubbleObject.TrySpawnFromBlock(context.Block.GetType(), context.BlockPosition.Value))
                    {
                        RubbleUtils.BreakBigRubble(context.BlockPosition.Value, 20 * SkillsUtil.GetSkillLevel(context.Player.User, typeof(StrongMiningSkill)));
                        context.Player.User.UserUI.OnCreateRubble.Invoke();
                    }
                return (InteractResult)result;
            }
            else if (context.Target is RubbleObject)
            {
                var rubble = (RubbleObject)context.Target;
                if (rubble.IsBreakable)
                {
                    rubble.Breakup();
                    BurnCalories(context.Player);
                    return InteractResult.Success;
                }
                else
                    return InteractResult.NoOp;
            }
            else
                return InteractResult.NoOp;
        }

        public override bool ShouldHighlight(Type block)
        {
            return Block.Is<Minable>(block);
        }

        public override InteractResult OnActRight(InteractionContext context)
        {
            User user = context.Player.User;
            if (context.HasBlock == false || user.Inventory.Carried.IsEmpty)
            {
                if (SkillsUtil.HasSkillLevel(user, typeof(MiningPickupAmountSkill), 1))
                {
                    RubbleUtils.PickUpRubble(user, 2 + (2 * SkillsUtil.GetSkillLevel(user, typeof(MiningPickupRangeSkill))), (4 * SkillsUtil.GetSkillLevel(user, typeof(MiningPickupAmountSkill))));
                    return InteractResult.Success;
                }
            }
            return InteractResult.NoOp;
        }
    }
}