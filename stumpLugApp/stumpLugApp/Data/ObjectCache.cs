using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace StumpLugApp.Data
{
    public static class ObjectCache
    {
        public static List<CourseArgs> CourseRootList
        {
            get { return JsonConvert.DeserializeObject<List<CourseArgs>>(File.ReadAllText("CourseData.json")); }
        }
        public static List<StudentArgs> StudentRootList
        {
            get { return JsonConvert.DeserializeObject<List<StudentArgs>>(File.ReadAllText("students.json")); }
        }
    }
}
