using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StumpLugApp.UI;

namespace StumpLugApp
{
    /// <summary>
    /// Class used to Define the Entry Point of the Application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry Point of the Application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Catch all unhandled Exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(App_UnhandledException);

            //Set the Window Name
            Console.Title = "StumpLug - Student Academic Record Service";

            //Load the MainMenu Page
            PageManager.Load(new MainMenuPage());
        }

        private static void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ErrorPage errorPage = new ErrorPage();
            errorPage.exception = (Exception)e.ExceptionObject;
            PageManager.Load(errorPage);
        }
    }
}
