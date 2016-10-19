using StumpLugApp.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

// https://github.com/Techie09/StumpLug/wiki/Business-Object-Layer
namespace StumpLugApp.Bus
{
    /// <summary>
    /// Represents a Course that can be taken
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/Course
    public partial class Course
    {
        #region Members
        /// <summary>
        /// represents the <see cref="string"/> "ID"
        /// </summary>
        public static string ID = "ID";
        private string m_id;
        /// <summary>
        /// a <see cref="string"/> representing the unique course Identity
        /// <para>Formatted as (Department)-(<see cref="number"/>)</para>
        /// </summary>
        public string id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Number"
        /// </summary>
        public static string Number = "Number";
        private string m_number;
        /// <summary>
        /// a <see cref="string"/> representing the course level within a department
        /// </summary>
        public string number
        {
            get { return m_number; }
            set { m_number = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Name"
        /// </summary>
        public static string Name = "Name";
        private string m_name;
        /// <summary>
        /// a <see cref="string"/> representing the course name
        /// </summary>
        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Credits"
        /// </summary>
        public static string Credits = "Credits";
        private string m_credits;
        /// <summary>
        /// a <see cref="string"/> representing how many hours the course is worth
        /// </summary>
        public string credits
        {
            get { return m_credits; }
            set { m_credits = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Course Type"
        /// </summary>
        public static string CourseType = "Course Type";
        private string m_courseType;
        /// <summary>
        /// a <see cref="string"/> representing the type of course.
        /// </summary>
        /// <see cref="CourseTypes"/>
        public string courseType
        {
            get { return m_courseType; }
            set { m_courseType = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes a <see cref="Course"/> using the <see cref="Course.Deserializer(CourseArgs)"/> Method
        /// </summary>
        /// <param name="args">represents data needed to populate a <see cref="Course"/></param>
        /// <see cref="CourseArgs"/>
        public Course(CourseArgs args)
        {
            Deserializer(args);
        }

        /// <summary>
        /// Copies <see cref="CourseArgs"/> data into a <see cref="Course"/> Object
        /// </summary>
        /// <param name="data">represents data needed to populate a <see cref="Course"/></param>
        /// <see cref="CourseArgs"/>
        public void Deserializer(CourseArgs data)
        {
            this.id = string.Format("{0}-{1}",data.DepartmentName, data.CourseNumber);
            this.name = data.CourseDescription;
            this.number = data.CourseNumber.ToString();
            this.courseType = data.CourseType;
            this.credits = data.CreditHours;
        }
        
        /// <summary>
        /// Returns the <see cref="string"/> "Course"
        /// </summary>
        /// <returns>"Course"</returns>
        public override string ToString() { return "Course"; }
        #endregion

        #region Search Methods
        /// <summary>
        /// Returns Course with specific matching id.
        /// </summary>
        /// <param name="idFind">a string value to search against strings</param>
        /// <returns></returns>
        public static Course GetCourseById(string idFind)
        {
            var courses = new Courses(ObjectCache.CourseRootList);
            Course course = courses.courses.FirstOrDefault(c => c.id == idFind);

            return course;
        }
        #endregion
    }
    
    /// <summary>
    /// Represents a collection of <see cref="Course"/> objects
    /// </summary>
    public class Courses
    {
        #region Members
        private List<Course> m_courses;
        /// <summary>
        /// Represents a <see cref="List{T}"/> of <see cref="Course"/> objects
        /// </summary>
        public List<Course> courses
        {
            get { return m_courses; }
            set { m_courses = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes <see cref="courses"/> using a <see cref="List{T}"/> of <see cref="CourseArgs"/> objects
        /// </summary>
        /// <param name="args">represents data needed to populate a <see cref="List{T}"/> of <see cref="Course"/> objects</param>
        /// <see cref="courses"/>
        public Courses(List<CourseArgs> args)
        {
            //Make sure courses is initialized. 
            courses = new List<Course>();
            //loop through all the courseArgs and store in courses
            foreach(CourseArgs data in args)
                courses.Add(new Course(data));
        }

        /// <summary>
        /// Returns the <see cref="string"/> "Courses"
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return "Courses"; }
        #endregion

        #region Search Methods
        /// <summary>
        /// Takes a list of courses and returns a list in which all courses have a name, id, or number that contains the search string.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Course> SearchCoursesGeneral(string search)
        {
            //normalie search tring for comparisons
            search = search.ToLower();
            //initialize courses to store results
            var courses = new Courses(ObjectCache.CourseRootList);
            //check if string is found within id, first name, or last name
            var studentsFound = courses.courses.Where(c => c.name.ToLower().Contains(search) || c.id.ToLower().Contains(search) || c.number.ToLower().Contains(search));

            return studentsFound.ToList();
        }
        #endregion
    }

    #region Enumerations
    /// <summary>
    /// Describes the course types available
    /// </summary>
    /// <see cref="Course.courseType"/>
    public enum CourseTypes
    {
        /// <summary>
        /// represents Core type of courses
        /// </summary>
        [Description("Core")]
        CORE,
        /// <summary>
        /// represents General education type of courses
        /// </summary>
        [Description("General Education")]
        GEN_ED,
        /// <summary>
        /// represents Elective type of courses
        /// </summary>
        [Description("Elective")]
        ELECTIVE
    }
    #endregion
}
