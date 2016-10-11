using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.Data
{
    public class EnrolledCourseArgs
    {
        public int CourseID { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public char Grade { get; set; }
    }
}
