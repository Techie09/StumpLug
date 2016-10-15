using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StumpLugApp.UI.PageManager;

namespace StumpLugApp.UI
{
    public abstract class SearchPage : Page
    {
        public string searchInput { get; set; }

        /// <summary>
        /// calls base.OnLoad() and sets cursor to visible
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override InputArgs HandleInput(InputArgs args)
        {
            args = base.HandleInput(args);
            if (!String.IsNullOrEmpty(args.input))
            {
                searchInput = args.input;
            }

            return args;
        }

        public override void Refresh()
        {
            searchInput = Console.ReadLine();

            //Display Search Results
            DisplayResults();

            //Do a base Refresh to reset the screen properly.
            base.Refresh();
        }

        public virtual void DisplayResults()
        {
            pageTitle = String.Format("{0}{1}", "Search Results for: ", searchInput);
            commands = new List<CommandsEnum>() { CommandsEnum.SearchAgain, CommandsEnum.MainMenu, CommandsEnum.Exit };
            Console.CursorVisible = false;
            base.ToScreen(canRefreshPage: false);
        }
    }
}
