using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace stumpLugApp.Data
{
    static class ObjectCache
    {
        private static List<CourseRoot> m_courseList;
        private static List<StudentRoot> m_studentList;

        public static List<CourseRoot> CourseList
        {
            get
            {
                return m_courseList;
            }
        }
        public static List<StudentRoot> StudentList
        {
            get
            {
                return m_studentList;
            }
        }

        public static void LoadObjectCache()
        {
            string jsonCourses = File.ReadAllText("CourseData.json");
            m_courseList = JsonConvert.DeserializeObject<List<CourseRoot>>(jsonCourses);

            string jsonStudents = File.ReadAllText("students.json");
            m_studentList = JsonConvert.DeserializeObject<List<StudentRoot>>(jsonStudents);
            //deserialize the .json 
        }
    }
}
