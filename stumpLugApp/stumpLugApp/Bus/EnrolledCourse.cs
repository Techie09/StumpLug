using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.Bus
{
    public partial class EnrolledCourse : Course
    {
        private SemesterType m_semester;
        public SemesterType Semester
        {
            get { return m_semester; }
            set { m_semester = value; }
        }

        private int m_year;
        public int Year
        {
            get { return m_year; }
            set { m_year = value; }
        }

        private LetterGrade m_grade;
        public LetterGrade Grade
        {
            get { return m_grade; }
            set { m_grade = value; }
        }

        public enum SemesterType
        {
            [Description("Fall")]
            FALL,
            [Description("Spring")]
            SPRING,
            [Description("Summer")]
            SUMMER
        }

        public enum LetterGrade
        {
            [Description("A")]
            A,
            [Description("B")]
            B,
            [Description("C")]
            C,
            [Description("D")]
            D,
            [Description("F")]
            F,
            [Description("Incomplete")]
            I,
            [Description("Withdraw")]
            W
        }
    }
}
