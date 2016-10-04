using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stumpLugApp.Bus;

namespace stumpLugApp.Data
{
    class StudentRoot
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int ID { get; set; }
        public List<int> CourseNumbers { get; set; }
    }
}
