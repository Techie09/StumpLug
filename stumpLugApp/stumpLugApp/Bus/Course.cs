using StumpLugApp.Data;
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

        private string m_credits;
        public string Credits
        {
            get { return m_credits; }
            set { m_credits = value; }
        }

        private string m_courseType;
        public string CourseType
        {
            get { return m_courseType; }
            set { m_courseType = value; }
        }

        public Course(CourseArgs args)
        {
            Deserializer(args);
        }

        /// <summary>
        /// Takes a list of courses and returns a list in which all courses have a name, id, or number that contains the search string.
        /// </summary>
        /// <param name="coursesOriginal"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Course> SearchCoursesGeneral(string search)
        {
            search = search.ToLower();
            var courses = new Courses(ObjectCache.CourseRootList);
            var studentsFound = courses.coursesList.Where(c => c.Name.ToLower().Contains(search) || c.Id.ToLower().Contains(search) || c.Number.ToLower().Contains(search));

            return studentsFound.ToList();
        }

        /// <summary>
        /// Returns Course with specific matching id.
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="idFind"></param>
        /// <returns></returns>
        public static Course GetCourseById(string idFind)
        {
            var courses = new Courses(ObjectCache.CourseRootList);
            Course course = courses.coursesList.FirstOrDefault(c => c.Id == idFind);

            return course;
        }

        public void Deserializer(CourseArgs data)
        {
            this.Id = string.Format("{0}-{1}",data.DepartmentName, data.CourseNumber);
            this.Name = data.CourseDescription;
            this.Number = data.CourseNumber.ToString();
            this.CourseType = data.CourseType;
            this.Credits = data.CreditHours;
        }
    }

    public class Courses
    {
        private List<Course> m_coursesList;
        public List<Course> coursesList
        {
            get { return m_coursesList; }
            set { m_coursesList = value; }
        }

        public Courses(List<CourseArgs> args)
        {
            coursesList = new List<Course>();
            foreach(CourseArgs data in args)
            {
                coursesList.Add(new Bus.Course(data));
            }
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
