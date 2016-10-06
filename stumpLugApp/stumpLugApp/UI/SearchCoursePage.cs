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
        public override void OnLoad()
        {
            pageTitle = "Course Search";
            content = "Search for a Course: ";
            base.OnLoad();
        }

        public override void DisplayResults()
        {
            content = String.Format("Found Course: {0}", searchInput);
            base.DisplayResults();
        }
    }
}
