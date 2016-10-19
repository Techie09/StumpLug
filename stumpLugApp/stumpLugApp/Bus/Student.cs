using StumpLugApp.Data;
using System.Collections.Generic;
using System.Linq;

// https://github.com/Techie09/StumpLug/wiki/Business-Object-Layer
namespace StumpLugApp.Bus
{
    /// <summary>
    /// Represents a <see cref="Student"/> within the application.  
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/Student
    public partial class Student
    {
        #region Members
        /// <summary>
        /// represents the <see cref="string"/> "ID"
        /// </summary>
        public static string ID = "ID";
        private string m_id;
        /// <summary>
        ///  a <see cref="string"/> representing the unique student identification
        /// </summary>
        public string id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "First Name"
        /// </summary>
        public static string FirstName = "First Name";
        private string m_firstName;
        /// <summary>
        /// a <see cref="string"/> representing the student's first name
        /// </summary>
        public string firstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Last Name"
        /// </summary>
        public static string LastName = "Last Name";
        private string m_lastName;
        /// <summary>
        /// a <see cref="string"/> representing the student's last name 
        /// </summary>
        public string lastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }

        /// <summary>
        /// represents the <see cref="string"/> "Courses"
        /// </summary>
        public static string Courses = "Courses";
        private List<EnrolledCourse> m_courses;
        /// <summary>
        /// represents a <see cref="List{T}"/> of <see cref="Course"/> the student has taken
        /// </summary>
        public List<EnrolledCourse> courses
        {
            get { return m_courses; }
            set { m_courses = value; }
        }

        /// <summary>
        /// Represents a formatted <see cref="Student.ID"/> #-##-####
        /// </summary>
        public string IdFormatted
        {
            get { return id.Substring(0, 7).Insert(1, "-").Insert(4, "-"); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes <see cref="Student"/> with <see cref="StudentArgs"/> using <see cref="Student.Deserialize(StudentArgs)"/> 
        /// </summary>
        /// <param name="args">Student data needed to fully populate a student</param>
        /// <see cref="StudentArgs"/> 
        public Student(StudentArgs args)
        {
            courses = new List<EnrolledCourse>();
            Deserialize(args);
        }

        /// <summary>
        /// Copies the Deserialized Json data into a Student
        /// </summary>
        /// <param name="data">raw data object for json-deserialized student</param>
        public void Deserialize(StudentArgs data)
        {
            this.id = data.ID.ToString();
            this.firstName = data.FName;
            this.lastName = data.LName;
            foreach (EnrolledCourseArgs args in data.Courses)
            {
                courses.Add(new EnrolledCourse(args));
            }
        }
        #endregion

        #region Search Methods
        /// <summary>
        /// Returns student with specific matching id.
        /// </summary>
        /// <param name="idFind"></param>
        /// <returns></returns>
        public static Student GetStudentById(string idFind)
        {
            var students = new Students(ObjectCache.StudentRootList);
            Student student = students.students.FirstOrDefault(s => s.id == idFind);

            return student;
        }
        #endregion


    }

    /// <summary>
    /// represents a collection of students
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/Students
    public class Students
    {
        private List<Student> m_students;
        /// <summary>
        /// represents a <see cref="List{T}"/> of <see cref="Student"/> objects
        /// </summary>
        public List<Student> students
        {
            get { return m_students; }
            set { m_students = value; }
        }

        #region Methods
        /// <summary>
        /// Initializes a <see cref="List{T}"/> of <see cref="StudentArgs"/> into <see cref="Students.students"/> 
        /// </summary>
        /// <param name="studentsArgsList">data needed to fully populate a <see cref="List{T}"/> of <see cref="Students"/></param>
        /// <see cref="StudentArgs"/>
        public Students(List<StudentArgs> studentsArgsList)
        {
            students = new List<Student>();
            foreach(StudentArgs data in studentsArgsList)
                students.Add(new Bus.Student(data));
        }

        /// <summary>
        /// Returns the <see cref="string"/> "Students" 
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return "Students"; }
        #endregion

        #region Search Methods
        /// <summary>
        /// Takes a list of students and returns a list in which all students have a first name, last name, or id that contains the search string.
        /// </summary>
        /// <param name="search">data needed to filter search results</param>
        /// <returns></returns>
        public static List<Student> SearchStudentsGeneral(string search)
        {
            search = search.ToLower();
            var students = new Students(ObjectCache.StudentRootList);
            var studentsFound = students.students.Where(s => s.firstName.ToLower().Contains(search) || s.lastName.ToLower().Contains(search) || s.id.ToLower().Contains(search));

            return studentsFound.ToList();
        }
        #endregion
    }
}
