using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace StumpLugApp.Bus
{
    public partial class Course
    {
        private string m_id;
        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_number;
        public string Number
        {
            get { return m_number; }
            set { m_number = value; }
        }

        private string m_name;
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private int m_credits;
        public int Credits
        {
            get { return m_credits; }
            set { m_credits = value; }
        }



        private CourseType m_courseType;
        public CourseType CourseType
        {
            get { return m_courseType; }
            set { m_courseType = value; }
        }

        /// <summary>
        /// Takes a list of courses and returns a list in which all courses have a name, id, or number that contains the search string.
        /// </summary>
        /// <param name="coursesOriginal"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Course> SearchCoursesGeneral(List<Course> coursesOriginal, string search)
        {
            var studentsFound = coursesOriginal.Where(c => c.Name.Contains(search) || c.Id.Contains(search) || c.Number.Contains(search));

            return studentsFound.ToList();
        }

        /// <summary>
        /// Returns Course with specific matching id.
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="idFind"></param>
        /// <returns></returns>
        public static Course GetCourseById(List<Course> courses, string idFind)
        {
            Course course = courses.FirstOrDefault(c => c.Id == idFind);

            return course;
        }
    }

    public enum CourseType
    {
        [Description("core")]
        CORE,
        [Description("general education")]
        GENED,
        [Description("elective")]
        ELECTIVE
    }
}
