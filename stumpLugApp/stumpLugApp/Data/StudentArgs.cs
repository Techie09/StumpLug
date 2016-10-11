using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.Data
{
    public class StudentArgs
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int ID { get; set; }
        public List<EnrolledCourseArgs> Courses { get; set; }
    }
}
