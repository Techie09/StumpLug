using StumpLugApp.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.UI
{
    class SearchCoursePage : SearchPage
    {
        private const string columnFormat = "{0,10}|{1}";

        public override void OnLoad()
        {
            pageTitle = "Course Search";
            content = "Search for a Course: ";
            base.OnLoad();
        }

        public override void DisplayResults()
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendLine(content);
            contentBuilder.AppendLine(String.Format(columnFormat, "CourseID", "Name"));
            var courses = Courses.SearchCoursesGeneral(searchInput);
            foreach (Course c in courses)
            {
                contentBuilder.AppendLine(String.Format(columnFormat, c.id, c.name));
            }
            Console.WriteLine(contentBuilder.ToString());
            //base.DisplayResults();
        }
    }
}
