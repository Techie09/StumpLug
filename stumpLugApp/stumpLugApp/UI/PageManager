using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace stumpLugApp.UI
{
    public static class PageManager
    {
        public static void Load(Page pageToLoad, bool clearScreen = true) // Sets clearScreen to true by default, so the argument is only needed when appending. 
        {
            if (clearScreen)
            {
                Console.Clear();
            }
            pageToLoad.OnLoad(); //Calling the setup method to format the newly loaded page.
        }
    }
}
