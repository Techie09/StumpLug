using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


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

        private Dictionary<CommandsEnum, ConsoleKey> m_commandsDict;
        public Dictionary<CommandsEnum, ConsoleKey> commandsDict
        {
            get { return m_commandsDict; }
            set { m_commandsDict = value; }
        }

        private PageManager()
        {
            commandsDict = new Dictionary<CommandsEnum, ConsoleKey>();
            AddCommand(CommandsEnum.Exit, ConsoleKey.X);
            AddCommand(CommandsEnum.MainMenu, ConsoleKey.M);
            AddCommand(CommandsEnum.SearchStudent, ConsoleKey.S);
            AddCommand(CommandsEnum.SearchCourse, ConsoleKey.C);
            AddCommand(CommandsEnum.SearchAgain, ConsoleKey.A);
        }

        public void AddCommand(CommandsEnum e, ConsoleKey key)
        {
            if (commandsDict == null || commandsDict.Keys.Contains(e) || commandsDict.Values.Contains(key))
                return;

            commandsDict.Add(e, key);
        }

        public void removeCommand(CommandsEnum e)
        {
            if (commandsDict == null || !commandsDict.Keys.Contains(e))
                return;

            commandsDict.Remove(e);
        }

        public void updateCommand(CommandsEnum e, ConsoleKey newKey)
        {
            if (commandsDict == null || !commandsDict.Keys.Contains(e) || !commandsDict.Values.Contains(newKey))
                return;

            commandsDict[e] = newKey;
        }

        public string DisplayCommand(CommandsEnum e)
        {
            return String.Format("[Alt+{0}]{1}", commandsDict[e].ToString(), e.GetDescription());
        }

        public static string CommandText(CommandsEnum cmd)
        {
            return pageManager.DisplayCommand(cmd);
        }

        public static void Load(Page pageToLoad, bool clearScreen = true) // Sets clearScreen to true by default, so the argument is only needed when appending. 
        {
            if (clearScreen)
                Console.Clear();
            
            pageManager.activePage = pageToLoad;
            pageManager.activePage.OnLoad(); //Call to output the newly loaded page.
            pageManager.activePage.ToScreen(); //Display stuff to the screen.
        }

        public static bool PageContainsCommand(CommandsEnum cmd)
        {
            return pageManager.activePage.commands.Contains(cmd);
        }

        public static InputArgs GetInput(bool displayInput=true)
        {
            InputArgs args = new InputArgs();
            args.KeyInfo = Console.ReadKey(displayInput);
                        
            return args;
        }

        public static void HandleNavigationInput(InputArgs input)
        {

            if (!input.isAltKeyPressed)
                return;

            if (PageContainsCommand(CommandsEnum.Exit) && input.Key == pageManager.commandsDict[CommandsEnum.Exit]) PageManager.pageManager.Exit();
            if (PageContainsCommand(CommandsEnum.MainMenu) && input.Key == pageManager.commandsDict[CommandsEnum.MainMenu]) pageManager.activePage.NavigateTo(new MainMenuPage());
            if (PageContainsCommand(CommandsEnum.SearchStudent) && input.Key == pageManager.commandsDict[CommandsEnum.SearchStudent]) pageManager.activePage.NavigateTo(new SearchStudentPage());
            if (PageContainsCommand(CommandsEnum.SearchCourse) && input.Key == pageManager.commandsDict[CommandsEnum.SearchCourse]) pageManager.activePage.NavigateTo(new SearchCoursePage());
            if (PageContainsCommand(CommandsEnum.SearchAgain) && input.Key == pageManager.commandsDict[CommandsEnum.SearchAgain]) PageManager.Load(PageManager.pageManager.activePage);
        }

        public void Exit()
        {
            if (ExitPrompt())
                Environment.Exit(0);

            else pageManager.activePage.ToScreen();
        }

        public bool ExitPrompt()
        {
            Console.Write("Are you sure you want to exit? (y/n): ");
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
                return true;

            return false;
        }
    }

    public enum CommandsEnum
    {
        [Description("Exit")]
        Exit,
        [Description("Main Menu")]
        MainMenu,
        [Description("Search Student")]
        SearchStudent,
        [Description("search Course")]
        SearchCourse,
        [Description("Search Again")]
        SearchAgain
    }
}
