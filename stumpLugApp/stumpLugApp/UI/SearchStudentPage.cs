using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StumpLugApp.UI.PageManager;

namespace StumpLugApp.UI
{
    class SearchStudentPage : SearchPage
    {
        public override void OnLoad()
        {
            pageTitle = "Student Search";
            content = "Search for a Student: ";

            base.OnLoad();
        }

        public override void DisplayResults()
        {
            content = String.Format("Found Student: {0}", searchInput);
            base.DisplayResults();
        }
    }
}
