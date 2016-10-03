using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    public abstract class Page
    {
        private const string appTitle = "StumpLug - Student Academic Record Service";
        protected const string horzRule = "------------------------------------------";


        // Basic formatting for when we change pages.
        public virtual void OnLoad()
        {
            Console.WriteLine(appTitle);
            Console.WriteLine(horzRule);
        }

        public virtual void NavigateTo(Page page)
        {
            bool canClose = OnClose();//stub
        }

        public virtual InputArgs GetInput()
        {
            InputArgs args = new InputArgs();
            args.KeyInfo = Console.ReadKey();
            return args;
            /*
            args.ActionKey = Console.ReadKey().Key;
            if (args.ActionKey == ConsoleKey.X) // If the user inputs X we don't want to take another char so we send the args to HandleInput()
            {
                return args;
            }
            args.TypeKey = Console.ReadKey().Key;
            Console.WriteLine(); // New line.
            return args;
            */
        }

        public virtual void HandleInput()
        {

        }

        public virtual bool OnClose()
        {
            return true; //stub
        }

        public bool ExitPrompt()
        {
            Console.WriteLine("Are you sure you want to exit? (y/n)");
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }

    }
}
