using StumpLugApp.Bus;
using StumpLugApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StumpLugApp.UI
{
    public class ViewStudentPage : Page
    {
        private Student m_student;
        public Student student
        {
            get { return m_student; }
            set { m_student = value; }
        }

        public override void OnLoad()
        {
            base.OnLoad();

            string columnFormat = "{0,-12}|{1,-27}|{2,-10}|{3,-7}|{4,-5}|{5,-8}|{6,-4}";
            pageTitle = String.Format("{0}{1},{2}", "Viewing Student: ", student.LastName, student.FirstName);
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendFormat("StudentID| {0}{1}", student.IdFormatted);
            contentBuilder.AppendLineFormat("     Name| {0}{1}", String.Format("{0} {1}", student.FirstName, student.LastName));
            contentBuilder.AppendLine(horzRule);
            contentBuilder.AppendLine("Courses");
            contentBuilder.AppendLine(horzRule);
            contentBuilder.AppendLineFormat(columnFormat, "CourseNumber", "CourseName", "CourseType", "Credits", "Grade", "Semester", "Year");
            foreach(EnrolledCourse enrolledCourse in student.Courses)
            {
                Course course = new Course(ObjectCache.CourseRootList.FirstOrDefault(cs => cs.CourseNumber == enrolledCourse.CourseNumber));
                contentBuilder.AppendFormat(columnFormat, course.number, course.name , course.courseType, course.credits, enrolledCourse.Grade, enrolledCourse.Semester.ToString(), enrolledCourse.Year);
            }
            content = contentBuilder.ToString();

            commands = new List<CommandsEnum> { CommandsEnum.SearchStudent, CommandsEnum.MainMenu, CommandsEnum.Exit };
        }
    }
}
