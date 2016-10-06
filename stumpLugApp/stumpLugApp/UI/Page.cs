using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    public abstract class Page
    {
        protected const string appTitle = "StumpLug - Student Academic Record Service";
        protected const string horzRule = "----------------------------------------------------------------";

        private string m_pageTitle = String.Empty;
        public string pageTitle
        {
            get { return m_pageTitle; }
            set { m_pageTitle = value; }
        }

        private List<commandsEnum> m_commands = new List<commandsEnum>();
        public List<commandsEnum> commands
        {
            get { return m_commands; }
            set { m_commands = value; }
        }

        private string m_content = String.Empty;
        public string content
        {
            get { return m_content; }
            set { m_content = value; }
        }

        public enum commandsEnum
        {
            Exit,
            MainMenu,
            SearchStudent,
            SearchCourse,
        }

        private Dictionary<commandsEnum, string> m_commandsDict;
        public Dictionary<commandsEnum, string> commandsDict
        {
            get { return m_commandsDict; }
            set { m_commandsDict = value; }
        }

        // Basic formatting for when we change pages.
        public virtual void OnLoad()
        {
            commandsDict = new Dictionary<commandsEnum, string>();
            commandsDict.Add(commandsEnum.Exit, "[Alt+X]Exit");
            commandsDict.Add(commandsEnum.MainMenu, "[Alt+M]Main Menu");
            commandsDict.Add(commandsEnum.SearchStudent, "[Shift+S]Student Search");
            commandsDict.Add(commandsEnum.SearchCourse, "[Shift+C]Course  Search");

            Console.Title = String.Format("{0} | {1}", appTitle, pageTitle);
            Console.WriteLine(horzRule);
            Console.WriteLine(pageTitle);
            Console.WriteLine(horzRule);
            foreach (commandsEnum c in commands)
            {
                if (c != commands.Last())
                    Console.Write(String.Format("{0} | ", commandsDict[c]));
                else
                    Console.WriteLine(commandsDict[c]);
            }
            Console.WriteLine(horzRule);
            Console.WriteLine(content);

            HandleInput();
        }

        public virtual void NavigateTo(Page page, bool clearScreen = true)
        {
            bool canClose = OnClose();
            if (canClose)
            {
                PageManager.Load(page, clearScreen);
            }
        }

        public virtual InputArgs GetInput()
        {
            InputArgs args = new InputArgs();
            args.KeyInfo = Console.ReadKey();
            return args;
        }

        public virtual void HandleInput()
        {
            //Put code which determines allowed commands here.
            InputArgs input = GetInput();
            if (commands.Contains(commandsEnum.Exit) && input.isAltKeyPressed && input.Key == ConsoleKey.X) { onClosing(); }
            if (commands.Contains(commandsEnum.MainMenu) && input.isAltKeyPressed && input.Key == ConsoleKey.M) { NavigateTo(new MainMenuPage()); }
            if (commands.Contains(commandsEnum.SearchStudent) && input.isShiftKeyPressed && input.Key == ConsoleKey.S) { NavigateTo(new SearchStudentPage()); }
            if (commands.Contains(commandsEnum.SearchCourse) && input.isShiftKeyPressed && input.Key == ConsoleKey.C) { NavigateTo(new SearchCoursePage()); }
            else NavigateTo(this);
        }

        public virtual void onClosing()
        {

            Console.WriteLine();
            if (ExitPrompt())
            {
                Environment.Exit(0);
            }
            else NavigateTo(this);
        }

        public virtual bool OnClose()
        {
            commands = new List<commandsEnum>();
            return true;
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
