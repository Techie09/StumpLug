using StumpLugApp.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.UI
{
    class SearchStudentPage : SearchPage
    {
        private const string columnFormat = "{0,13}|{1,9}|{2,-30}|{3}";

        public override void OnLoad()
        {
            pageTitle = "Student Search";
            content = "Search for a Student: ";
            base.OnLoad();
        }

        public override void DisplayResults()
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLine(String.Format(columnFormat, "Option Select", "StudentID", "Name", "Completed Courses"));
            var students = Student.SearchStudentsGeneral(searchInput);
            int i = 1;
            //generate formatted students to display
            foreach (Student s in students)
            {
                string name = String.Format("{0},{1}", s.LastName, s.FirstName);
                contentBuilder.AppendLine(String.Format(columnFormat, i, s.IdFormatted, name, s.Courses.Count));
                i++;
            }
            
            //If there is a student to display, display results. 
            if(students.Count > 0)
            {
                content = contentBuilder.ToString();
                base.DisplayResults();
                ViewStudentPage page = new ViewStudentPage();

                //if there is only one, ask if user would like to view the student details
                if (students.Count == 1)
                {
                    Console.Write("Would you like to view the Student in detail?[Y/N]: ");
                    var cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Y)
                    {
                        //user wants student detail
                        page.student = students.First();
                        PageManager.Load(page);
                    }
                    else
                    {
                        //user wants to navigate to different page
                        PageManager.HandleNavigationInput(new InputArgs(cki));
                    }
                }
                else if (students.Count > 1)
                {
                    content = contentBuilder.ToString();
                    base.DisplayResults();
                    //if there is more than one results, 
                    Console.Write("select a Student to view in detail?: ");
                    var input = Console.ReadLine();
                    int option;

                    //keep trying until the user gives valid input
                    while (!int.TryParse(input, out option) && option > 0 && option <= students.Count)
                    {
                        input = Console.ReadLine();
                    }
                    page.student = students[option - 1]; //option is off by one for display.
                    PageManager.Load(page);
                }
            }
            else
            {
                content = "No Search Results Found";
                base.DisplayResults();
                while (true)
                {
                    PageManager.HandleNavigationInput(PageManager.GetInput(true));
                }
            }
           

        }
    }
}
