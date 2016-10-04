using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stumpLugApp.UI;

namespace stumpLugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.TreatControlCAsInput = true; //We refuse to change
            PageManager.Load(new MainMenuPage());
        }
    }
}
