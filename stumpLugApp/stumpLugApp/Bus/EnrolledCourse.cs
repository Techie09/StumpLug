using StumpLugApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// represents the Business Object Layer
/// </summary>
/// <see cref="https://github.com/Techie09/StumpLug/wiki/Business-Object-Layer"/>
namespace StumpLugApp.Bus
{
    /// <summary>
    /// Represents a <see cref="Course"/> a <see cref="Student"/> is Enrolled in.  
    /// </summary>
    /// /// <see cref="https://github.com/Techie09/StumpLug/wiki/EnrolledCourse"/>
    public partial class EnrolledCourse
    {
        #region Members
        public static string Info = "Info";
        private Course m_Info;
        /// <summary>
        /// represents the <see cref="Course"/> data
        /// </summary>
        public Course info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }

        public static string CourseID = "Course ID";
        private int m_courseID;
        /// <summary>
        /// represents the course
        /// </summary>
        public int courseID
        {
            get { return m_courseID; }
            set { m_courseID = value; }
        }

        public static string Semester = "Semester";
        private SemesterType m_semester;
        /// <summary>
        /// represents a <see cref="semester"/> of the course the student has taken.
        /// </summary>
        /// <see cref="SemesterType"/> 
        public SemesterType semester
        {
            get { return m_semester; }
            set { m_semester = value; }
        }

        public static string Year = "Year";
        private int m_year;
        /// <summary>
        /// represents the <see cref="year"/> the student took the course. 
        /// </summary>
        public int year
        {
            get { return m_year; }
            set { m_year = value; }
        }

        public static string Grade = "Grade";
        private LetterGrade m_grade;
        /// <summary>
        /// represents the <see cref="LetterGrade"/> earned
        /// </summary>
        public LetterGrade grade
        {
            get { return m_grade; }
            set { m_grade = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes the <see cref="EnrolledCourseArgs"/> data into the <see cref="EnrolledCourse"/> object 
        /// </summary>
        /// <param name="args"></param>
        public EnrolledCourse(EnrolledCourseArgs args)
        {
            var cArgs = ObjectCache.CourseRootList.FirstOrDefault(c => c.CourseNumber == args.CourseID);
            if (cArgs == null)
                return;
            info = new Course(cArgs);
            courseID = args.CourseID;
            semester = (SemesterType)args.Semester;
            year = args.Year;
            semester = ParseSemester("spring");
        }

        /// <summary>
        /// determines which <see cref="SemesterType"/> base on the semesterName 
        /// </summary>
        /// <param name="semesterName">only valid options: Fall(default), Spring, Summer </param>
        /// <returns>returns SemesterType based on semesterName. defaults to Fall</returns>
        /// <remarks>needs finished</remarks>
        public SemesterType ParseSemester(string semesterName)
        {
            var semesterType = SemesterType.FALL;

            var name = Enum.GetName(typeof(SemesterType), SemesterType.FALL);

            return semesterType;
        }
        #endregion
    }

    #region Enumerations
    /// <summary>
    /// Represents the different types of semesters
    /// </summary>
    public enum SemesterType
    {
        [Description("Fall")]
        FALL,
        [Description("Spring")]
        SPRING,
        [Description("Summer")]
        SUMMER
    }

    /// <summary>
    /// Represents different grades that can be earned for a course
    /// </summary>
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
    #endregion
}
