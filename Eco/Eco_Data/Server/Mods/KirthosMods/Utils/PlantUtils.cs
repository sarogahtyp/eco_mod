using Eco.Gameplay.Items;
using Eco.Gameplay.Plants;
using Eco.Gameplay.Players;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.World;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirthos.Mods
{
    class PlantUtils
    {
        public static void GetPlantBlockAroundPoint(User user, Vector3i position, int range)
        {
            try
            {
                for (int i = -range; i < range; i++)
                {
                    for (int j = -range; j < range; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        Vector3i positionAbove = World.GetTopPos(new Vector2i(position.x + i, position.z + j)) + Vector3i.Up;
                        Block blockAbove = World.GetBlockProbablyTop(positionAbove);
                        if (blockAbove is CornBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<CornItem>(6))
                                {
									if (user.Inventory.TryAddItems<CornSeedItem> (3))
									{
                                    World.DeleteBlock(positionAbove);
									}
                                }
                            }
                        }
						else if (blockAbove is TomatoesBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<TomatoItem>(6))
                                {
                                    if (user.Inventory.TryAddItems<TomatoSeedItem> (3))
									{
                                    World.DeleteBlock(positionAbove);
									}
                                }
                            }
                        }
						else if (blockAbove is FireweedBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<FireweedShootsItem>(6))
                                {
                                    if (user.Inventory.TryAddItems<FireweedSeedItem> (3))
									{
                                    World.DeleteBlock(positionAbove);
									}
                                }
                            }
                        }
						else if (blockAbove is WheatBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<WheatItem>(5))
                                {
                                    if (user.Inventory.TryAddItems<WheatSeedItem> (3))
									{
                                    World.DeleteBlock(positionAbove);
									}
                                }
                            }
                        }
						else if (blockAbove is BeetsBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<BeetItem>(5))
                                {
                                    if (user.Inventory.TryAddItems<BeetSeedItem> (3))
									{
                                    World.DeleteBlock(positionAbove);
									}
                                }
                            }
                        }
						else if (blockAbove is BeansBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<BeansItem>(5))
                                {
                                    World.DeleteBlock(positionAbove);
                                }
                            }
                        }
						else if (blockAbove is RiceBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<RiceItem>(5))
                                {
                                    World.DeleteBlock(positionAbove);
                                }
                            }
                        }
						else if (blockAbove is FernBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<FiddleheadsItem>(5))
                                {
                                    if (user.Inventory.TryAddItems<FernSporeItem> (3))
									{
                                    World.DeleteBlock(positionAbove);
									}
                                }
                            }
                        }
						else if (blockAbove is KelpBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<KelpItem>(5))
                                {
                                    World.DeleteBlock(positionAbove);
                                }
                            }
                        }
						else if (blockAbove is PricklyPearBlock)
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<PricklyPearFruitItem>(5))
                                {
                                    World.DeleteBlock(positionAbove);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
