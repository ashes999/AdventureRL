using DeenGames.AdventureRL.UI.SadConsoleMonogame.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeenGames.AdventureRL.UI.SadConsoleMonogame
{
    class Game
    {
        public void Run()
        {
            // Setup the engine and creat the main window.
            SadConsole.Engine.Initialize("IBM.font", Config.GameWidth, Config.GameHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Engine.EngineStart += (sender, eventArgs) =>
            {
                // Clear the default console
                SadConsole.Engine.ConsoleRenderStack.Clear();
                SadConsole.Engine.ActiveConsole = null;

                SadConsole.Engine.ConsoleRenderStack.Add(new AreaScreen());
            };

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Engine.EngineUpdated += (sender, eventArgs) =>
            {
            };

            // Start the game.
            SadConsole.Engine.Run();
        }
    }
}
