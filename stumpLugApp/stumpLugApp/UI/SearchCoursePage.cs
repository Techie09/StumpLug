using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    class SearchCoursePage : Page
    {
        public override void OnLoad()
        {
            pageTitle = "Course Search";
            commands = new List<commandsEnum>() { commandsEnum.Exit, commandsEnum.MainMenu };
            content = "Search for a Course: ";

            base.OnLoad();
        }
    }
}
