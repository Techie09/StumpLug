using System.Collections.Generic;

namespace stumpLugApp.Bus
{
    public class Student
    {
        private string m_id;
        private string m_firstName;
        private string m_lastName;
        private List<EnrolledCourse> m_courses;

        public string Id
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }
        public string FirstName
        {
            get
            {
                return m_firstName;
            }
            set
            {
                m_firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return m_lastName;
            }
            set
            {
                m_lastName = value;
            }
        }
        public List<EnrolledCourse> Courses
        {
            get
            {
                return m_courses;
            }
            set
            {
                m_courses = value;
            }
        }
    }
}
