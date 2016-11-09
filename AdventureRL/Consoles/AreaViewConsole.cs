﻿using System;
using Microsoft.Xna.Framework;
using SadConsole.Game;
using SadConsole;
using SadConsole.Input;
using DeenGames.AdventureRL.UI.SadConsoleMonogame.SadConsoleHelpers.Extensions;
using Microsoft.Xna.Framework.Input;
using DeenGames.AdventureRL.UI.SadConsoleMonogame.View;

namespace DeenGames.AdventureRL.UI.SadConsoleMonogame.Consoles
{
    class AreaViewConsole : SadConsole.Consoles.Console
    {
        public GameObject playerEntity { get; private set; }
        private CellAppearance[,] mapData;
        private RogueSharp.Map rogueMap;

        public AreaViewConsole(int width, int height, int mapWidth, int mapHeight) : base(mapWidth, mapHeight)
        {
            this.TextSurface.RenderArea = new Rectangle(0, 0, width, height);
            this.playerEntity = new GameObject(Engine.DefaultFont);
            this.playerEntity.Move(1, 1);
            this.playerEntity.DrawAs('@', Color.Orange);

            SadConsole.Engine.ActiveConsole = this;
            // Keyboard setup
            SadConsole.Engine.Keyboard.RepeatDelay = 0.07f;
            SadConsole.Engine.Keyboard.InitialRepeatDelay = 0.1f;

            this.GenerateMap();
        }

        public override void Render()
        {
            base.Render();
            playerEntity.Render();
        }

        public override void Update()
        {
            base.Update();
            playerEntity.Update();
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            if (info.KeysPressed.Contains(AsciiKey.Get(Keys.Down)) || info.KeysPressed.Contains(AsciiKey.Get(Keys.S)))
            {
                this.MovePlayerBy(new Point(0, 1));
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Keys.Up)) || info.KeysPressed.Contains(AsciiKey.Get(Keys.W)))
            {
                this.MovePlayerBy(new Point(0, -1));
            }

            if (info.KeysPressed.Contains(AsciiKey.Get(Keys.Right)) || info.KeysPressed.Contains(AsciiKey.Get(Keys.D)))
            {
                this.MovePlayerBy(new Point(1, 0));
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Keys.Left)) || info.KeysPressed.Contains(AsciiKey.Get(Keys.A)))
            {
                this.MovePlayerBy(new Point(-1, 0));
            }

            return false;
        }

        private void MovePlayerBy(Point amount)
        {
            // Get the position the player will be at
            Point newPosition = playerEntity.Position + amount;

            // Check to see if the position is within the map
            if (new Rectangle(0, 0, Width, Height).Contains(newPosition)
                && rogueMap.IsWalkable(newPosition.X, newPosition.Y))
            {
                // Move the player
                playerEntity.Position += amount;
                CenterViewToPlayer();
            }
        }

        private void CenterViewToPlayer()
        {
            // Scroll the view area to center the player on the screen
            TextSurface.RenderArea = new Rectangle(playerEntity.Position.X - (TextSurface.RenderArea.Width / 2),
                                                    playerEntity.Position.Y - (TextSurface.RenderArea.Height / 2),
                                                    TextSurface.RenderArea.Width, TextSurface.RenderArea.Height);

            // If he view area moved, we'll keep our entity in sync with it.
            playerEntity.RenderOffset = this.Position - TextSurface.RenderArea.Location;
        }

        private void GenerateMap()
        {
            // Create the map
            var mapCreationStrategy = new RogueSharp.MapCreation.RandomRoomsMapCreationStrategy<RogueSharp.Map>(this.Width, this.Height, 100, 15, 4);

            rogueMap = RogueSharp.Map.Create(mapCreationStrategy);

            // Create the local cache of map data
            mapData = new CellAppearance[this.Width, this.Height];

            // Loop through the map information generated by RogueSharp and create our cached visuals of that data
            foreach (var cell in rogueMap.GetAllCells())
            {
                if (cell.IsWalkable)
                {
                    // Our local information about each map square
                    mapData[cell.X, cell.Y] = new Floor();

                    // Copy the appearance we've defined for Floor or Wall or whatever, to the actual console data that is rendered
                    mapData[cell.X, cell.Y].CopyAppearanceTo(this[cell.X, cell.Y]);
                }
                else
                {
                    mapData[cell.X, cell.Y] = new Wall();
                    mapData[cell.X, cell.Y].CopyAppearanceTo(this[cell.X, cell.Y]);
                }
            }

            // TODO: dependency to inject
            var  random = new RogueSharp.Random.DotNetRandom();

            // Position the player somewhere on a walkable square
            int x = random.Next(this.Width);
            int y = random.Next(this.Height);

            while (!(rogueMap.IsWalkable(x, y)))
            {
                x = random.Next(this.Width);
                y = random.Next(this.Height);
                playerEntity.Position = new Point(x, y);
            }

            this.CenterViewToPlayer();
        }
    }
}
