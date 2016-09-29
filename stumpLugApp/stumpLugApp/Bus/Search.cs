using System.Collections.Generic;
using System.Linq;

namespace stumpLugApp.Bus
{
    public static class Search
    {
        /*
         * Takes a list of students and returns a list in which all students have a first name, last name, or id that contains the search string.
         */
        public static List<Student> SearchStudentsGeneral(List<Student> studentsOriginal, string search)
        {
            var studentsFound = studentsOriginal.Where(s => s.FirstName.Contains(search) || s.LastName.Contains(search) || s.Id.Contains(search));

            return studentsFound.ToList();
        }

        /*
         * Returns student with specific matching id.
         */
        public static Student GetStudentById(List<Student> students, string idFind)
        {
            Student student = students.FirstOrDefault(s => s.Id == idFind);

            return student;
        }

        /*
         * Takes a list of courses and returns a list in which all courses have a name, id, or number that contains the search string.
         */
        public static List<Course> SearchCoursesGeneral(List<Course> coursesOriginal, string search)
        {
            var studentsFound = coursesOriginal.Where(c => c.Name.Contains(search) || c.Id.Contains(search) || c.Number.Contains(search));

            return studentsFound.ToList();
        }
        
        /*
         * Returns course with specific matching id.
         */
        public static Course GetCourseById(List<Course> courses, string idFind)
        {
            Course course = courses.FirstOrDefault(c=> c.Id == idFind);

            return course;
        }
    }
}
