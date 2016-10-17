using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// represents the UI Layer
/// </summary>
/// <see cref="https://github.com/Techie09/StumpLug/wiki/User-Interface"/>
namespace StumpLugApp.UI
{
    /// <summary>
    /// Controller for Navigating between Pages.
    /// </summary>
    /// <see cref="https://github.com/Techie09/StumpLug/wiki/Page-Manager"/>
    public class PageManager
    {
        #region Members
        private static PageManager m_pageManager = new PageManager();
        /// <summary>
        /// Singleton instance of PageManager
        /// </summary>
        public static PageManager pageManager
        {
            get { return m_pageManager; }
            set { m_pageManager = value; }
        }
        
        private Page m_activePage = null;
        /// <summary>
        /// <seealso cref="Page"/> that the Controller is actively controlling.
        /// </summary>
        public Page activePage
        {
            get { return m_activePage; }
            set { m_activePage = value; }
        }
        
        private Dictionary<CommandsEnum, string> m_commandsDict;
        /// <summary>
        /// Dictionary used to Map commands to string that are displayed.
        /// </summary>
        public Dictionary<CommandsEnum, string> commandsDict
        {
            get { return m_commandsDict; }
            set { m_commandsDict = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes Singleton instance of <see cref="PageManager"/>.
        /// </summary>
        private PageManager()
        {
            commandsDict = new Dictionary<CommandsEnum, string>();
            commandsDict.Add(CommandsEnum.Exit, "[Alt+X]Exit");
            commandsDict.Add(CommandsEnum.MainMenu, "[Alt+M]Main Menu");
            commandsDict.Add(CommandsEnum.SearchStudent, "[Alt+S]Student Search");
            commandsDict.Add(CommandsEnum.SearchCourse, "[Alt+C]Course Search");
            commandsDict.Add(CommandsEnum.SearchAgain, "[Alt+A]Search Again");
        }

        /// <summary>
        /// calls <see cref="ExitPrompt"/> and then either exits the application or calls activePage.ToScreen()
        /// </summary>
        public void Exit()
        {
            if (ExitPrompt()) //prompt is user really wants to exit
                Environment.Exit(0); //exit application

            //recover application
            else pageManager.activePage.ToScreen();
        }

        /// <summary>
        /// Prompts user if they want to Exit the application.
        /// </summary>
        /// <returns>true if exiting. false to return to the application</returns>
        public bool ExitPrompt()
        {
            Console.Write("Are you sure you want to exit? (y/n): ");
            ConsoleKey input = Console.ReadKey().Key;
            if (input == ConsoleKey.Y)
                return true;

            return false;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Loads a specific Page.
        /// <list>PageManager.activePage is set and the activePage is loaded</list>
        /// </summary>
        /// <param name="pageToLoad">A Page for the Page Manager to load</param>
        /// <param name="clearScreen"></param>
        public static void Load(Page pageToLoad, bool clearScreen = true) // Sets clearScreen to true by default, so the argument is only needed when appending. 
        {
            //may want screen appended
            if (clearScreen)
                Console.Clear();

            //load Page and make initial toScreen
            pageManager.activePage = pageToLoad; //Sets active Page
            pageManager.activePage.OnLoad(); //Call to output the newly loaded page.
            pageManager.activePage.ToScreen(); //Display stuff to the screen.
        }

        /// <summary>
        /// Gets the string that describes a command
        /// </summary>
        /// <param name="cmd">a <see cref="CommandsEnum"/> representing a valid command within the application.</param>
        /// <returns>string from dictionary</returns>
        /// <remarks> command needs validated before returning. </remarks>
        public static string CommandText(CommandsEnum cmd)
        {
            return pageManager.commandsDict[cmd];
        }

        /// <summary>
        /// Checks if the command exists in the <see cref="Page.commands"/> 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static bool PageContainsCommand(CommandsEnum cmd)
        {
            return pageManager.activePage.commands.Contains(cmd);
        }


        /// <summary>
        /// Get input from console. Can disable console echo(writing input to output). 
        /// </summary>
        /// <param name="displayInput"></param>
        /// <returns></returns>
        public static InputArgs GetInput(bool displayInput = true)
        {
            InputArgs args = new InputArgs();
            args.KeyInfo = Console.ReadKey(displayInput);

            return args;
        }

        /// <summary>
        /// Handles Page Navigations. Requires pressing Alt and then validates command exists on Page.
        /// </summary>
        /// <param name="input">represents data collected from Console input</param>
        /// <seealso cref="InputArgs"/> 
        public static void HandleNavigationInput(InputArgs input)
        {
            //Alt key must be pressed
            if (!input.isAltKeyPressed)
                return;

            //Check each command and the related consoleKey, if valid run the associated Page
            if (PageContainsCommand(CommandsEnum.Exit) && input.IsKeyPressed(ConsoleKey.X)) PageManager.pageManager.Exit();
            if (PageContainsCommand(CommandsEnum.MainMenu) && input.IsKeyPressed(ConsoleKey.M)) pageManager.activePage.NavigateTo(new MainMenuPage());
            if (PageContainsCommand(CommandsEnum.SearchStudent) && input.IsKeyPressed(ConsoleKey.S)) pageManager.activePage.NavigateTo(new SearchStudentPage());
            if (PageContainsCommand(CommandsEnum.SearchCourse) && input.IsKeyPressed(ConsoleKey.C)) pageManager.activePage.NavigateTo(new SearchCoursePage());
            if (PageContainsCommand(CommandsEnum.SearchAgain) && input.IsKeyPressed(ConsoleKey.A)) PageManager.Load(PageManager.pageManager.activePage);
        }
        #endregion
    }

    /// <summary>
    /// enumeration that contains all the possible commands available.
    /// </summary>
    public enum CommandsEnum
    {
        [Description("Exit")]
        Exit,
        [Description("Main Menu")]
        MainMenu,
        [Description("Search Student")]
        SearchStudent,
        [Description("Search Course")]
        SearchCourse,
        [Description("Search Again")]
        SearchAgain
    }
}
