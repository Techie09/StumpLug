using StumpLugApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace StumpLugApp.Bus
{
    public partial class Student
    {
        public string Id { get; set; }

        private string m_firstName;
        public string FirstName
        {
            get { return m_firstName; }
            set { m_firstName = value; }
        }

        private string m_lastName;
        public string LastName
        {
            get { return m_lastName; }
            set { m_lastName = value; }
        }

        private List<EnrolledCourse> m_courses;
        public List<EnrolledCourse> Courses
        {
            get { return m_courses; }
            set { m_courses = value; }
        }

        public Student() { }

        public Student(StudentArgs args)
        {
            Courses = new List<EnrolledCourse>();
            Deserialize(args);
        }

        public string IdFormatted
        {
            get { return Id.Substring(0, 7).Insert(1, "-").Insert(4, "-"); }
        }

        /// <summary>
        /// Takes a list of students and returns a list in which all students have a first name, last name, or id that contains the search string.
        /// </summary>
        /// <param name="studentsOriginal"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Student> SearchStudentsGeneral(string search)
        {
            search = search.ToLower();
            var students = new Students(ObjectCache.StudentRootList);
            var studentsFound = students.StudentList.Where(s => s.FirstName.ToLower().Contains(search) || s.LastName.ToLower().Contains(search) || s.Id.ToLower().Contains(search));

            return studentsFound.ToList();
        }

        /// <summary>
        /// Returns student with specific matching id.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="idFind"></param>
        /// <returns></returns>
        public static Student GetStudentById(string idFind)
        {
            var students = new Students(ObjectCache.StudentRootList);
            Student student = students.StudentList.FirstOrDefault(s => s.Id == idFind);

            return student;
        }

        /// <summary>
        /// Copies the Deserialized Json data into a Student
        /// </summary>
        /// <param name="data">raw data object for json-deserialized student</param>
        public void Deserialize(StudentArgs data)
        {
            this.Id = data.ID.ToString();
            this.FirstName = data.FName;
            this.LastName = data.LName;
            foreach(EnrolledCourseArgs args in data.Courses)
            {
                Courses.Add(new EnrolledCourse(args));
            }
        }
    }

    public class Students
    {
        private List<Student> m_studentList;
        public List<Student> StudentList
        {
            get { return m_studentList; }
            set { m_studentList = value; }
        }

        public Students(List<StudentArgs> studentsArgsList)
        {
            StudentList = new List<Student>();
            foreach(StudentArgs data in studentsArgsList)
            {
                StudentList.Add(new Bus.Student(data));
            }
        }
    }
}
