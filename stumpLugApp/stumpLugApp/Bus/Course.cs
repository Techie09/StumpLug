using StumpLugApp.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace StumpLugApp.Bus
{
    /// <summary>
    /// Business Object representing a Course.
    /// </summary>
    public partial class Course
    {
        #region Members
        private string m_id;
        /// <summary>
        /// Unique ID to represent a Course
        /// </summary>
        public string id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_number;
        /// <summary>
        /// Course Number used to define the course within a department
        /// </summary>
        public string number
        {
            get { return m_number; }
            set { m_number = value; }
        }

        private string m_name;
        /// <summary>
        /// Course Name used to briefly describe the course
        /// </summary>
        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private string m_credits;
        /// <summary>
        /// Course Credits describe the number of hours awarded for successfully completing the course
        /// </summary>
        public string credits
        {
            get { return m_credits; }
            set { m_credits = value; }
        }

        private string m_courseType;
        /// <summary>
        /// CourseType defined as a CORE, ELECTIVE, or GENED
        /// </summary>
        public string courseType
        {
            get { return m_courseType; }
            set { m_courseType = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a Course based on a set of Course Arguments
        /// </summary>
        /// <param name="args"></param>
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
            var studentsFound = courses.coursesList.Where(c => c.name.ToLower().Contains(search) || c.id.ToLower().Contains(search) || c.number.ToLower().Contains(search));

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
            Course course = courses.coursesList.FirstOrDefault(c => c.id == idFind);

            return course;
        }

        public void Deserializer(CourseArgs data)
        {
            this.id = string.Format("{0}-{1}",data.DepartmentName, data.CourseNumber);
            this.name = data.CourseDescription;
            this.number = data.CourseNumber.ToString();
            this.courseType = data.CourseType;
            this.credits = data.CreditHours;
        }

        #endregion
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
