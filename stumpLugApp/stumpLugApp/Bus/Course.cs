using System.ComponentModel;

namespace stumpLugApp.Bus
{
    public class Course
    {
        private string m_id;
        private string m_number;
        private string m_name;
        private int m_credits;
        private int m_year;

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
        public string Number
        {
            get
            {
                return m_number;
            }
            set
            {
                m_number = value;
            }
        }
        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
        public int Credits
        {
            get
            {
                return m_credits;
            }
            set
            {
                m_credits = value;
            }
        }
        public int Year
        {
            get
            {
                return m_year;
            }
            set
            {
                m_year = value;
            }
        }
    }

    public class EnrolledCourse : Course
    {
        private Semester m_semester;
        private CourseType m_courseType;
        private LetterGrade m_letterGrade;

        public Semester Semester
        {
            get
            {
                return m_semester;
            }
            set
            {
                m_semester = value;
            }
        }
        public CourseType CourseType
        {
            get
            {
                return m_courseType;
            }
            set
            {
                m_courseType = value;
            }
        }
        public LetterGrade LetterGrade
        {
            get
            {
                return m_letterGrade;
            }
            set
            {
                m_letterGrade = value;
            }
        }
    }

    public enum Semester
    {
        [Description("fall")]
        FALL,
        [Description("spring")]
        SPRING,
        [Description("summer")]
        SUMMER
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

    public enum LetterGrade
    {
        A,B,C,D,F,I,W
    }
}
