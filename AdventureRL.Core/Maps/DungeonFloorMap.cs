﻿using RogueSharp;
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
        private int width = 0;
        private int height = 0;

        public DungeonFloorMap(int width, int height)
        {
            this.width = width;
            this.height = height;

            var mapCreationStrategy = new RogueSharp.MapCreation.RandomRoomsMapCreationStrategy<RogueSharp.Map>(width, height, 100, 15, 4);
            this.tileData = RogueSharp.Map.Create(mapCreationStrategy);
        }

        /// <summary>
        /// Sets the player's starting position. In dungeons, it's the next/previous floor.
        /// For now, it's just a random, walkable location.
        public Point GetPlayerStartingPosition()
        {
            // TODO: dependency to inject
            var random = new RogueSharp.Random.DotNetRandom();

            // Position the player somewhere on a walkable square
            int x = random.Next(this.width);
            int y = random.Next(this.height);

            while (!(tileData.IsWalkable(x, y)))
            {
                x = random.Next(this.width);
                y = random.Next(this.height);
            }

            return new Point(x, y);
        }

        public bool IsWalkable(int x, int y)
        {
            // TODO: make sure there are no entities there, eg. player, monster
            return this.tileData.IsWalkable(x, y); 
        }
    }
}
