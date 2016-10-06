using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    class SearchStudentPage : Page
    {
        private string header = "Student Search";
        public override void OnLoad()
        {
            pageTitle = "Student Search";
            commands = new List<commandsEnum>() { commandsEnum.Exit, commandsEnum.MainMenu };
            content = "Search for a student";

            base.OnLoad();
        }
    }
}
