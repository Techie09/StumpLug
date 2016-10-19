using System;
using System.Collections.Generic;
using System.Linq;

// https://github.com/Techie09/StumpLug/wiki/User-Interface-Layer
namespace StumpLugApp.UI
{
    /// <summary>
    /// represents a PAge to be displayed
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/Page
    public abstract class Page
    {
        #region Members
        /// <summary>
        /// represents the <see cref="string"/> "StumpLug - Student Academic Record Service"
        /// </summary>
        protected const string appTitle = "StumpLug - Student Academic Record Service";
        /// <summary>
        /// represents the <see cref="string"/> "----------------------------------------------------------------"
        /// </summary>
        protected const string horzRule = "----------------------------------------------------------------";

        /// <summary>
        /// represents input retreived from console
        /// </summary>
        protected List<char> inputString;
      
        /// <summary>
        /// represents the title of the Page
        /// </summary>
        public string pageTitle { get; set; }

        /// <summary>
        /// represents a <see cref="List{T}"/>  of <see cref="CommandsEnum"/>  that can performed on this page
        /// </summary>
        public List<CommandsEnum> commands { get; set; }
        
        /// <summary>
        /// reresents content to be displayed in console
        /// </summary>
        public string content { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// a virtual OnLoad used to intialize values, and handle the page freely. called from <see cref="PageManager"/> 
        /// </summary>
        public virtual void OnLoad()
        {
            inputString = new List<char>();
            commands = new List<CommandsEnum>();
        }

        /// <summary>
        /// a virtual ToScreen used to display the Page to the console. called from <see cref="PageManager"/> after OnLoad
        /// </summary>
        /// <param name="clearScreen"></param>
        /// <param name="canRefreshPage"></param>
        public virtual void ToScreen(bool clearScreen = true, bool canRefreshPage = true)
        {
            if (clearScreen)
                Console.Clear();

            Console.Title = String.Format("{0} | {1}", appTitle, pageTitle);

            //name of Page written to Console
            Console.WriteLine(horzRule);
            Console.WriteLine(pageTitle);
            Console.WriteLine(horzRule);

            //write formatted commands to console
            foreach (CommandsEnum c in commands)
            {
                if (c != commands.Last())
                    Console.Write(String.Format("{0} | ", PageManager.CommandText(c)));
                else
                    Console.WriteLine(PageManager.CommandText(c));
            }
            if(commands.Count > 0)
                Console.WriteLine(horzRule);

            //write and basic content
            Console.Write(content);

            //toggle for pages designed for viewing
            if(canRefreshPage)
                Refresh();
        }

        /// <summary>
        /// Refreshes the Page by handling input, navigation, and calling ToScreen
        /// </summary>
        public virtual void Refresh()
        {
            //Get Input and process input
            InputArgs args = PageManager.GetInput(true);

            //Navigate to a different page?
            PageManager.HandleNavigationInput(args);

            //handle input normally
            PageManager.pageManager.activePage.HandleInput(args);

            //output
            PageManager.pageManager.activePage.ToScreen();
        }

        /// <summary>
        /// Navigate away from Page using this method
        /// </summary>
        /// <param name="page"></param>
        /// <param name="clearScreen"></param>
        public virtual void NavigateTo(Page page, bool clearScreen = true)
        {
            bool canClose = OnClose();
            if (canClose)
            {
                PageManager.Load(page, clearScreen);
            }
        }

        /// <summary>
        /// virtual HandleInput processes the input in a default manner by reading Key Presses and returns InputArgs
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual InputArgs HandleInput(InputArgs args)
        {
            if (args.Key == ConsoleKey.Enter)
            {
                //send input with input args, clear inputString
                args.input = String.Join(String.Empty, inputString);
                inputString = new List<char>();
            }
            else
            {
                inputString.Add(args.keyInfo.KeyChar);
            }

            return args;
        }

        /// <summary>
        /// viruatl OnClose that runs when the Page is being closed. can return false to prevent closing.
        /// </summary>
        /// <returns></returns>
        public virtual bool OnClose()
        {
            commands = new List<CommandsEnum>();
            return true;
        }
        #endregion
    }
}
