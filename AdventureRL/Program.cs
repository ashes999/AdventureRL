using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Console = SadConsole.Consoles.Console;
using DeenGames.AdventureRL.Consoles;
using Microsoft.Xna.Framework;

namespace DeenGames.AdventureRL
{
    class Program
    {
        private const int MessageConsoleHeight = 6;
        private const int GameWidth = 80;
        private const int GameHeight = 25;

        static void Main(string[] args)
        {
            // Setup the engine and creat the main window.
            SadConsole.Engine.Initialize("IBM.font", GameWidth, GameHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Engine.EngineStart += Engine_EngineStart;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Engine.EngineUpdated += Engine_EngineUpdated;

            // Start the game.
            SadConsole.Engine.Run();
        }

        private static void Engine_EngineStart(object sender, EventArgs e)
        {
            // Clear the default console
            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ActiveConsole = null;

            var viewConsole = new BorderedConsole(GameWidth, GameHeight - MessageConsoleHeight);
            var messageConsole = new BorderedConsole(GameWidth, MessageConsoleHeight, "Messages");

            viewConsole.Position = new Point(0, 0);
            messageConsole.Position = new Point(0, viewConsole.Height);

            SadConsole.Engine.ConsoleRenderStack.Add(viewConsole);
            SadConsole.Engine.ConsoleRenderStack.Add(messageConsole);
        }

        private static void Engine_EngineUpdated(object sender, EventArgs e)
        {

        }
    }

}