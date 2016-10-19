// https://github.com/Techie09/StumpLug/wiki/Data-Acess-Layer 
namespace StumpLugApp.Data
{
    /// <summary>
    /// represents enrolled course data retreived from file
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/EnrolledCourseArgs
    public class EnrolledCourseArgs
    {
        /// <summary>
        /// represents the Unique Identification of a Course
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// represents the Semester the course was taken
        /// </summary>
        public int Semester { get; set; }
        /// <summary>
        /// represents the year the course was taken
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// represents the grade earned from taking the course
        /// </summary>
        public char Grade { get; set; }
    }
}
