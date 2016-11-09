using SadConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AdventureRL.Core.Maps
{
    // DERP: why do we have MonoGame here? We shouldn't.
    public class Wall : CellAppearance
    {
        public Wall() : base(Color.White, Color.Transparent, '#')
        {

        }
    }
}
