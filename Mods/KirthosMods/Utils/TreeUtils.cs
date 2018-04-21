using Eco.Gameplay.Items;
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
    class TreeUtils
    {
        public static void GetPulpAroundPoint(User user, Vector3i position, int range)
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
                        if (blockAbove.Is<TreeDebris>())
                        {
                            if (positionAbove != position && Vector3i.Distance(positionAbove, position) < range)
                            {
                                if (user.Inventory.TryAddItems<WoodPulpItem>(5))
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
