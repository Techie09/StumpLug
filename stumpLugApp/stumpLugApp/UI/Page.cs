using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static stumpLugApp.UI.PageManager;

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

        public virtual void Init()
        {

        }

        public virtual void OnLoad()
        {

        }

        public virtual void ToScreen(bool clearScreen = true)
        {
            if (clearScreen)
                Console.Clear();

            Console.Title = String.Format("{0} | {1}", appTitle, pageTitle);
            Console.WriteLine(horzRule);
            Console.WriteLine(pageTitle);
            Console.WriteLine(horzRule);
            foreach (commandsEnum c in commands)
            {
                if (c != commands.Last())
                    Console.Write(String.Format("{0} | ", PageManager.CommandText(c)));
                else
                    Console.WriteLine(PageManager.CommandText(c));
            }
            Console.WriteLine(horzRule);
            Console.Write(content);

            PageManager.Refresh();
        }

        public virtual bool canRefreshPage
        {
            get { return true; }
        }

        public virtual void NavigateTo(Page page, bool clearScreen = true)
        {
            bool canClose = OnClose();
            if (canClose)
            {
                PageManager.Load(page, clearScreen);
            }
        }

        public virtual void HandleInput(InputArgs input)
        {

        }

        public virtual void onClosing()
        {
        }

        public virtual bool OnClose()
        {
            commands = new List<commandsEnum>();
            return true;
        }

    }
}
