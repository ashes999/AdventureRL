using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeenGames.AdventureRL.Core.Maps
{
    public class DungeonFloorMap
    {
        private RogueSharp.Map tileData;

        public DungeonFloorMap(int width, int height)
        {
            var mapCreationStrategy = new RogueSharp.MapCreation.RandomRoomsMapCreationStrategy<RogueSharp.Map>(width, height, 100, 15, 4);
            this.tileData = RogueSharp.Map.Create(mapCreationStrategy);
        }

        public bool IsWalkable(int x, int y)
        {
            // TODO: make sure there are no entities there, eg. player, monster
            return this.tileData.IsWalkable(x, y); 
        }
    }
}
