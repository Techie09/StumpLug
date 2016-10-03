using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    public class MainMenuPage : Page
    {
        private string header = "Main Menu";

        public override void OnLoad()
        {
            base.OnLoad();
            Console.WriteLine(header);
            Console.WriteLine(horzRule);
            Console.WriteLine("Alt + X | Exit");
            Console.WriteLine("Shift + S | Search for a Student");
            Console.WriteLine("Ctrl + S | Add a Student");
            Console.WriteLine("Shift + C | Search for a Course");
            Console.WriteLine("Ctrl + C | Add a Course");


            HandleInput();
                      
        }

        public override void NavigateTo(Page page)
        { 
            base.NavigateTo(page);
            if (page.GetType() == typeof(AddStudentPage)) 
            {
                PageManager.Load(page);
            }
            else if (page.GetType() == typeof(SearchStudentPage))
            {
                PageManager.Load(page);
            }
            else if (page.GetType() == typeof(AddCoursePage))
            {
                PageManager.Load(page);
            }
            else if (page.GetType() == typeof(SearchCoursePage))
            {
                PageManager.Load(page);
            }
        }

        public override void HandleInput()
        {
            InputArgs input = GetInput();
            if (input.isAltKeyPressed && input.Key == ConsoleKey.X)
            {
                Console.Clear();
                if (ExitPrompt())
                {
                    Environment.Exit(0);
                }
                else NavigateTo(new MainMenuPage());
            }
            if (input.isShiftKeyPressed && input.Key == ConsoleKey.S)
            {
                NavigateTo(new SearchStudentPage());
            }
            if (input.isCtrlKeyPressed && input.Key == ConsoleKey.S)
            {
                NavigateTo(new AddStudentPage());
            }
            if (input.isShiftKeyPressed && input.Key == ConsoleKey.C)
            {
                NavigateTo(new SearchCoursePage());
            }
            if (input.isCtrlKeyPressed && input.Key == ConsoleKey.C)
            {
                NavigateTo(new AddCoursePage());
            }
            else
                HandleInput();
        }
    }
}
