using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stumpLugApp.UI
{
    public class MainMenuPage : Page
    {
        public override void OnLoad()
        {
            pageTitle = "Main Menu";
            commands.AddRange(new List<commandsEnum> { commandsEnum.Exit, commandsEnum.SearchStudent, commandsEnum.SearchCourse });
            content = "Enter an option: ";

            base.OnLoad();
        }
    }
}
