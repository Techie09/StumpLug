using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StumpLugApp.UI
{
    public class PageManager
    {
        //Lamest Singleton implementation ever! 
        private static PageManager m_pageManager = new PageManager();
        public static PageManager pageManager
        {
            get { return m_pageManager; }
            set { m_pageManager = value; }
        }

        private Page m_activePage = null;
        public Page activePage
        {
            get { return m_activePage; }
            set { m_activePage = value; }
        }

        private List<char> inputString; //stores a collection of char reads from console.In

        public enum commandsEnum
        {
            Exit,
            MainMenu,
            SearchStudent,
            SearchCourse,
            SearchAgain
        }

        private Dictionary<commandsEnum, string> m_commandsDict;
        public Dictionary<commandsEnum, string> commandsDict
        {
            get { return m_commandsDict; }
            set { m_commandsDict = value; }
        }

        private PageManager()
        {
            commandsDict = new Dictionary<commandsEnum, string>();
            commandsDict.Add(commandsEnum.Exit, "[Alt+X]Exit");
            commandsDict.Add(commandsEnum.MainMenu, "[Alt+M]Main Menu");
            commandsDict.Add(commandsEnum.SearchStudent, "[Alt+S]Student Search");
            commandsDict.Add(commandsEnum.SearchCourse, "[Alt+C]Course Search");
            commandsDict.Add(commandsEnum.SearchAgain, "[Alt+A]Search Again");

            inputString = new List<char>();
        }

        public static string CommandText(commandsEnum cmd)
        {
            return pageManager.commandsDict[cmd];
        }

        public static void Load(Page pageToLoad, bool clearScreen = true) // Sets clearScreen to true by default, so the argument is only needed when appending. 
        {
            pageManager.inputString = new List<char>();
            if (clearScreen)
                Console.Clear();

            pageManager.activePage = pageToLoad;
            pageManager.activePage.Init(); //setup variables
            pageManager.activePage.OnLoad(); //Call to output the newly loaded page.
            pageManager.activePage.ToScreen(); //Display stuff to the screen.
        }

        public static void Refresh()
        {
            //Get Input and process input
            InputArgs args = GetInput();
            pageManager.activePage.HandleInput(args);

            if (!pageManager.activePage.canRefreshPage)
                Refresh();

            //output
            pageManager.activePage.ToScreen();
        }

        public static bool PageContainsCommand(commandsEnum cmd)
        {
            return pageManager.activePage.commands.Contains(cmd);
        }

        public static InputArgs GetInput()
        {
            InputArgs args = new InputArgs();
            args.KeyInfo = Console.ReadKey();
            if (args.isAltKeyPressed)
                HandleNavigationInput(args);

            if (args.Key == ConsoleKey.Enter)
            {
                //send input with input args, clear inputString
                args.input = String.Join(String.Empty, pageManager.inputString);
                pageManager.inputString = new List<char>();
            }
            else
            {
                pageManager.inputString.Add(args.KeyInfo.KeyChar);
            }
            return args;
        }

        public static void HandleNavigationInput(InputArgs input)
        {

            if (!input.isAltKeyPressed)
                return;

            if (PageContainsCommand(commandsEnum.Exit) && input.Key == ConsoleKey.X) PageManager.pageManager.Exit();
            if (PageContainsCommand(commandsEnum.MainMenu) && input.Key == ConsoleKey.M) pageManager.activePage.NavigateTo(new MainMenuPage());
            if (PageContainsCommand(commandsEnum.SearchStudent) && input.Key == ConsoleKey.S) pageManager.activePage.NavigateTo(new SearchStudentPage());
            if (PageContainsCommand(commandsEnum.SearchCourse) && input.Key == ConsoleKey.C) pageManager.activePage.NavigateTo(new SearchCoursePage());
            if (PageContainsCommand(commandsEnum.SearchAgain) && input.Key == ConsoleKey.A) PageManager.Load(PageManager.pageManager.activePage);
        }

        public void Exit()
        {
            Console.WriteLine();
            if (ExitPrompt())
            {
                Environment.Exit(0);
            }
            else pageManager.activePage.ToScreen();
        }

        public bool ExitPrompt()
        {
            Console.Write("Are you sure you want to exit? (y/n): ");
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }
    }
}
