using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.UI
{
    public class MainMenuPage : Page
    {
        public override void OnLoad()
        {
            //Initializing some Page variables
            base.OnLoad();

            pageTitle = "Main Menu";
            commands.AddRange(new List<CommandsEnum> { CommandsEnum.SearchStudent, CommandsEnum.Exit });
            content = "Enter an option: ";
            Console.CursorVisible = false;
        }
    }
}
