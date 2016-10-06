using System.Collections.Generic;
using System.Linq;

namespace StumpLugApp.Bus
{
    public partial class Student
    {
        private string m_id;
        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

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

        /// <summary>
        /// Takes a list of students and returns a list in which all students have a first name, last name, or id that contains the search string.
        /// </summary>
        /// <param name="studentsOriginal"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Student> SearchStudentsGeneral(List<Student> studentsOriginal, string search)
        {
            var studentsFound = studentsOriginal.Where(s => s.FirstName.Contains(search) || s.LastName.Contains(search) || s.Id.Contains(search));

            return studentsFound.ToList();
        }

        /// <summary>
        /// Returns student with specific matching id.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="idFind"></param>
        /// <returns></returns>
        public static Student GetStudentById(List<Student> students, string idFind)
        {
            Student student = students.FirstOrDefault(s => s.Id == idFind);

            return student;
        }
    }
}
