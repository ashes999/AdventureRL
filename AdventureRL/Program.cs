using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Console = SadConsole.Consoles.Console;
using DeenGames.AdventureRL.Consoles;
using Microsoft.Xna.Framework;
using DeenGames.AdventureRL.Screens;

namespace DeenGames.AdventureRL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup the engine and creat the main window.
            SadConsole.Engine.Initialize("IBM.font", Config.GameWidth, Config.GameHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Engine.EngineStart += Engine_EngineStart;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Engine.EngineUpdated += Engine_EngineUpdated;

            // Start the game.
            SadConsole.Engine.Run();
        }

        private static void Engine_EngineStart(object sender, EventArgs e)
        {
            SadConsole.Engine.ConsoleRenderStack.Add(new AreaScreen());
            SadConsole.Engine.ActiveConsole = null;
        }

        private static void Engine_EngineUpdated(object sender, EventArgs e)
        {

        }
    }

}