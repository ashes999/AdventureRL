using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeenGames.AdventureRL.Consoles
{
    class BorderedConsole : SadConsole.Consoles.Console
    {
        public BorderedConsole(int width, int height, string title = "") : base(width, height)
        {
            SadConsole.Shapes.Box box = SadConsole.Shapes.Box.GetDefaultBox();
            box.Width = width;
            box.Height = height;
            box.Foreground = Color.LightGray;

            box.Draw(this);


            if (!string.IsNullOrWhiteSpace(title))
            {
                this.Print((width - title.Length) / 2, 0, title);
            }
        }
    }
}
