using StumpLugApp.Bus;
using System;
using System.Text;

// https://github.com/Techie09/StumpLug/wiki/User-Interface-Layer
namespace StumpLugApp.UI
{
    /// <summary>
    /// represents Course Search
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/SearchCoursePage
    class SearchCoursePage : SearchPage
    {
        private const string columnFormat = "{0,10}|{1}";

        /// <summary>
        /// override of OnLoad to set page title and content.
        /// </summary>
        public override void OnLoad()
        {
            pageTitle = "Course Search";
            content = "Search for a Course: ";
            base.OnLoad();
        }

        /// <summary>
        /// override Display Results to show Course information found
        /// </summary>
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
        }
    }
}
