using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StumpLugApp.UI.PageManager;

namespace StumpLugApp.UI
{
    public class MainMenuPage : Page
    {
        public override void OnLoad()
        {
            pageTitle = "Main Menu";
            commands.AddRange(new List<commandsEnum> { commandsEnum.SearchStudent, commandsEnum.SearchCourse, commandsEnum.Exit });
            content = "Enter an option: ";
            Console.CursorVisible = false;
            base.OnLoad();
        }
    }
}
