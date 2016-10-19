using System;
using System.Collections.Generic;

// https://github.com/Techie09/StumpLug/wiki/User-Interface-Layer
namespace StumpLugApp.UI
{
    /// <summary>
    /// Represent the base functionality for Search Pages
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/SearchPage
    public abstract class SearchPage : Page
    {
        /// <summary>
        /// represent the search criteria entered by the user
        /// </summary>
        public string searchInput { get; set; }

        /// <summary>
        /// override of OnLoad which calls base to initialize Page, and then sets commands and makes cursor visible
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();
            commands = new List<CommandsEnum>() { };
            Console.CursorVisible = true;
        }

        /// <summary>
        /// Override of HandleInput to retreive user input from console and store in <see cref="searchInput"/>
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

        /// <summary>
        /// override of Refresh to get searchInput and Display Results. base Refresh is called to handle navigation
        /// </summary>
        public override void Refresh()
        {
            searchInput = Console.ReadLine();

            //Display Search Results
            DisplayResults();

            //Do a base Refresh to reset the screen properly.
            base.Refresh();
        }

        /// <summary>
        /// virtual of DisplayResults to display search results to the screen.
        /// </summary>
        public virtual void DisplayResults()
        {
            pageTitle = String.Format("{0}{1}", "Search Results for: ", searchInput);
            commands = new List<CommandsEnum>() { CommandsEnum.SearchAgain, CommandsEnum.MainMenu, CommandsEnum.Exit };
            Console.CursorVisible = false;
            base.ToScreen(canRefreshPage: false);
        }
    }
}
