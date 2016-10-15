using StumpLugApp.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StumpLugApp.UI.PageManager;

namespace StumpLugApp.UI
{
    class SearchCoursePage : SearchPage
    {
        private const string columnFormat = "{0,10}|{1}";

        /// <summary>
        /// calls base.OnLoad() and sets Page Title and content
        /// </summary>
        public override void OnLoad()
        {
            base.OnLoad();
            pageTitle = "Course Search";
            content = "Search for a Course: ";
        }

        /// <summary>
        /// Displays all the courses found.
        /// </summary>
        public override void DisplayResults()
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLine(content);
            contentBuilder.AppendLineFormat(columnFormat, "CourseID", "Name");
            var courses = Course.SearchCoursesGeneral(searchInput);
            foreach (Course course in courses)
            {
                contentBuilder.AppendLineFormat(columnFormat, course.id, course.name);
            }
            Console.WriteLine(contentBuilder.ToString());
            //base.DisplayResults();
        }
    }
}
