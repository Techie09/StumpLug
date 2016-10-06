using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    class SearchCoursePage : Page
    {
        private string header = "Search for a Course";
        public override void OnLoad()
        {
            base.OnLoad();
            Console.WriteLine(header);
            Console.WriteLine(horzRule);
            Console.WriteLine("Alt + X | Exit");
            Console.WriteLine("Alt + M | Main Menu");

            HandleInput();
        }
        public override void NavigateTo(Page page)
        {
            base.NavigateTo(page);
            if (page.GetType() == typeof(MainMenuPage))
            {
                PageManager.Load(page);
            }

        }
        public override void HandleInput()
        {
            base.HandleInput();
            InputArgs input = GetInput();
            if (input.isAltKeyPressed && input.Key == ConsoleKey.M)
            {
                NavigateTo(new MainMenuPage());
            }
            if (input.isAltKeyPressed && input.Key == ConsoleKey.X)
            {
                Console.Clear();
                if (ExitPrompt())
                {
                    Environment.Exit(0);
                }
                else NavigateTo(new MainMenuPage());
            }
        }
    }
}
