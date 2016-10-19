// https://github.com/Techie09/StumpLug/wiki/Data-Acess-Layer 
namespace StumpLugApp.Data
{
    /// <summary>
    /// represents course data retreived from file
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/CourseArgs 
    public class CourseArgs
    {
        /// <summary>
        /// represents the name of a department
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// represents the description of a course
        /// </summary>
        public string CourseDescription { get; set; }
        /// <summary>
        /// represents the type of course
        /// </summary>
        public string CourseType { get; set; }
        /// <summary>
        /// represents the course level within a department
        /// </summary>
        public int CourseNumber { get; set; }
        /// <summary>
        /// represents the number of hours earned for completing the course
        /// </summary>
        public string CreditHours { get; set; }
    }
}

