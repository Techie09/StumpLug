using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StumpLugApp.UI.PageManager;

namespace StumpLugApp.UI
{
    public abstract class Page
    {
        protected const string appTitle = "StumpLug - Student Academic Record Service";
        protected const string horzRule = "----------------------------------------------------------------";

        protected List<char> inputString; //stores a collection of char reads from console.In
      
        public string pageTitle { get; set; }
        public List<commandsEnum> commands { get; set; }
        
        public string content { get; set; }

        public virtual void OnLoad()
        {
            inputString = new List<char>();
            commands = new List<commandsEnum>();
        }

        public virtual void ToScreen(bool clearScreen = true, bool canRefreshPage = true)
        {
            if (clearScreen)
                Console.Clear();

            Console.Title = String.Format("{0} | {1}", appTitle, pageTitle);

            //Name of Page written to Console
            Console.WriteLine(horzRule);
            Console.WriteLine(pageTitle);
            Console.WriteLine(horzRule);

            //write formatted commands to console
            foreach (commandsEnum c in commands)
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

        public virtual void Refresh()
        {
            //Get Input and process input
            InputArgs args = GetInput(false);

            //Navigate to a different page?
            HandleNavigationInput(args);

            //handle input normally
            pageManager.activePage.HandleInput(args);

            //output
            pageManager.activePage.ToScreen();
        }

        public virtual void NavigateTo(Page page, bool clearScreen = true)
        {
            bool canClose = OnClose();
            if (canClose)
            {
                PageManager.Load(page, clearScreen);
            }
        }

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
                inputString.Add(args.KeyInfo.KeyChar);
            }

            return args;
        }

        public virtual bool OnClose()
        {
            commands = new List<commandsEnum>();
            return true;
        }

    }
}
