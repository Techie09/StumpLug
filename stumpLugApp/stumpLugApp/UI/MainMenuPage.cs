using System;
using System.Collections.Generic;

// https://github.com/Techie09/StumpLug/wiki/User-Interface-Layer
namespace StumpLugApp.UI
{
    /// <summary>
    /// represents the Main Menu in Console. inherits <see cref="Page"/> 
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/MainMenuPage
    public class MainMenuPage : Page
    {
        /// <summary>
        /// <see cref="Page"/>.OnLoad() override that sets the page Title, commands, content and hide the mouse.
        /// </summary>
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
