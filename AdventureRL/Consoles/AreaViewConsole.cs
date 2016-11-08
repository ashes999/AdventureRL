using System;
using Microsoft.Xna.Framework;
using SadConsole.Game;
using SadConsole;
using SadConsole.Input;
using DeenGames.AdventureRL.UI.SadConsoleMonogame.SadConsoleHelpers.Extensions;
using Microsoft.Xna.Framework.Input;

namespace DeenGames.AdventureRL.UI.SadConsoleMonogame.Consoles
{
    class AreaViewConsole : SadConsole.Consoles.Console
    {
        public GameObject playerEntity { get; private set; }

        public AreaViewConsole(int width, int height, int mapWidth, int mapHeight) : base(width, height)
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

        private void MovePlayerBy(Point point)
        {
            this.playerEntity.Position += point;
        }

        private void GenerateMap()
        {
            Random random = new Random();

            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    if (i == 0 || j == 0 || i == this.Width - 1 || j == this.Height - 1)
                    {
                        this[i + (j * this.Width)].GlyphIndex = '#';
                    }
                    else
                    {
                        this[i + (j * this.Width)].GlyphIndex = '.';
                    }
                }
            }
        }
    }
}
