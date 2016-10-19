using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://github.com/Techie09/StumpLug/wiki/Data-Acess-Layer
namespace StumpLugApp.Data
{
    /// <summary>
    /// represents the Student data retreived from file
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/StudentArgs
    public class StudentArgs
    {
        /// <summary>
        /// represents the First Name of a student
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// represents the Last Name of a student
        /// </summary>
        public string LName { get; set; }
        /// <summary>
        /// represents the unique identification of a student
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// represents a <see cref="List{T}"/> of <see cref="EnrolledCourseArgs"/> the student has taken  
        /// </summary>
        public List<EnrolledCourseArgs> Courses { get; set; }
    }
}
