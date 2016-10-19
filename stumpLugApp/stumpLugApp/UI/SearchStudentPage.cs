using StumpLugApp.Bus;
using System;
using System.Collections.Generic;
using System.Text;

// https://github.com/Techie09/StumpLug/wiki/User-Interface-Layer
namespace StumpLugApp.UI
{
    /// <summary>
    /// represents a Student Search Page
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/SearchStudentPage
    class SearchStudentPage : SearchPage
    {
        private const string columnFormat = "{0,13}|{1,9}|{2,-30}|{3}";

        /// <summary>
        /// override OnLoad to set pageTitle and content
        /// </summary>
        public override void OnLoad()
        {
            pageTitle = "Student Search";
            content = "Search for a Student: ";
            base.OnLoad();
        }

        /// <summary>
        /// override Display Results to show students found and to select a specific student to display details
        /// </summary>
        public override void DisplayResults()
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLine(String.Format(columnFormat, "Option Select", Student.ID, "Name", "Completed Courses"));
            var students = Students.SearchStudentsGeneral(searchInput);
            int i = 1;
            //generate formatted students to display
            foreach (Student s in students)
            {
                string name = String.Format("{0},{1}", s.lastName, s.firstName);
                contentBuilder.AppendLine(String.Format(columnFormat, i, s.IdFormatted, name, s.courses.Count));
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
                    FoundOneStudent(page, students[0]);
                }
                else if (students.Count > 1)
                {
                    content = contentBuilder.ToString();
                    FoundManyStudents(page, students);
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

        /// <summary>
        /// Handles displaying One Student
        /// </summary>
        /// <param name="page">data need</param>
        /// <param name="student"></param>
        public void FoundOneStudent(ViewStudentPage page, Student student)
        {
            Console.Write("Would you like to view the Student in detail?[Y/N]: ");
            var cki = Console.ReadKey();
            if (cki.Key == ConsoleKey.Y)
            {
                //user wants student detail
                page.student = student;
                PageManager.Load(page);
            }
            else
            {
                //user wants to navigate to different page
                PageManager.HandleNavigationInput(new InputArgs(cki));
            }
        }

        /// <summary>
        /// Handles select one Student from Many found
        /// </summary>
        /// <param name="page"></param>
        /// <param name="students"></param>
        public void FoundManyStudents(ViewStudentPage page, List<Student> students)
        {
            base.DisplayResults();
            //if there is more than one results
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
}
