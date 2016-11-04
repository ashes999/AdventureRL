using System;
using Microsoft.Xna.Framework;
using SadConsole.Game;
using SadConsole;
using DeenGames.AdventureRL.SadConsoleHelpers.Extensions;

namespace DeenGames.AdventureRL.Consoles
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
    }
}
