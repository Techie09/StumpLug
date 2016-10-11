using StumpLugApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.Bus
{
    public partial class EnrolledCourse
    {
        private Course m_Info;
        public Course Info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }

        public int CourseNumber { get; set; }
        public SemesterType Semester { get; set; }
        public int Year { get; set; }
        public LetterGrade Grade { get; set; }

        public EnrolledCourse(EnrolledCourseArgs args)
        {
            var cArgs = ObjectCache.CourseRootList.FirstOrDefault(c => c.CourseNumber == args.CourseID);
            if (cArgs == null)
                return;
            Info = new Course(cArgs);
            CourseNumber = args.CourseID;
            Semester = (SemesterType)args.Semester;
            Year = args.Year;
            Semester = ParseSemester("spring");
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

        public SemesterType ParseSemester(string semesterName)
        {
            var semesterType = SemesterType.FALL;

            var name = Enum.GetName(typeof(SemesterType), SemesterType.FALL);

            return semesterType;
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
