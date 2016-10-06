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
        private string m_searchInput = String.Empty;
        public string searchInput
        {
            get { return m_searchInput; }
            set { m_searchInput = value; }
        }

        private bool m_isSearching = false;
        public bool isSearching
        {
            get { return m_isSearching; }
        }

        public override void OnLoad()
        {
            Console.CursorVisible = true;
            commands = new List<commandsEnum>() { commandsEnum.MainMenu, commandsEnum.Exit };
            base.OnLoad();
        }

        public override void HandleInput(InputArgs inputArgs)
        {
            if (!String.IsNullOrEmpty(inputArgs.input))
            {
                searchInput = inputArgs.input;
                m_isSearching = true;
            }
            else
            {
                m_isSearching = false;
            }
        }

        public override void ToScreen(bool clearScreen = true)
        {
            if (isSearching)
            {
                DisplayResults();
            }
            else
                base.ToScreen();
        }

        public override bool canRefreshPage
        {
            get { return isSearching; }
        }

        public virtual void DisplayResults()
        {
            pageTitle = "Search Results";
            commands = new List<commandsEnum>() { commandsEnum.SearchAgain, commandsEnum.MainMenu, commandsEnum.Exit };
            m_isSearching = false;
            Console.CursorVisible = false;
            base.ToScreen();
        }
    }
}
