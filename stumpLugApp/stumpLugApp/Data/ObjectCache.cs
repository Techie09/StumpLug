using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// https://github.com/Techie09/StumpLug/wiki/Data-Acess-Layer
namespace StumpLugApp.Data
{
    /// <summary>
    /// represents Data Connectors implemented in their most basic form
    /// </summary>
    /// https://github.com/Techie09/StumpLug/wiki/ObjectCache 
    public static class ObjectCache
    {
        /// <summary>
        /// Returns an unfiltered <see cref="List{T}"/> of <see cref="CourseArgs"/> from file
        /// </summary>
        /// <remarks>need to call safely</remarks>
        public static List<CourseArgs> CourseRootList { get { return JsonConvert.DeserializeObject<List<CourseArgs>>(File.ReadAllText("CourseData.json")); } }
        /// <summary>
        /// Returns an unfiltered <see cref="List{T}"/> of <see cref="StudentArgs"/> from file
        /// </summary>
        /// <remarks>need to call safely</remarks>
        public static List<StudentArgs> StudentRootList { get { return JsonConvert.DeserializeObject<List<StudentArgs>>(File.ReadAllText("students.json")); } }
    }
}
