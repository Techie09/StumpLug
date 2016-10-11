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

            string columnFormat = "{0,-12}|{1,-27}|{2,-10}|{3,-7}|{4,-5}|{5,-8}|{6,-4}{7}";
            pageTitle = String.Format("{0}{1},{2}", "Viewing Student: ", student.LastName, student.FirstName);
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.AppendFormat("StudentID| {0}{1}", student.IdFormatted, Environment.NewLine);
            contentBuilder.AppendFormat("     Name| {0}{1}", String.Format("{0} {1}", student.FirstName, student.LastName), Environment.NewLine);
            contentBuilder.AppendLine(horzRule);
            contentBuilder.AppendLine("Courses");
            contentBuilder.AppendLine(horzRule);
            contentBuilder.AppendFormat(columnFormat, "CourseNumber", "CourseName", "CourseType", "Credits", "Grade", "Semester", "Year", Environment.NewLine);
            foreach(EnrolledCourse ec in student.Courses)
            {
                Course c = new Course(ObjectCache.CourseRootList.FirstOrDefault(cs => cs.CourseNumber == ec.CourseNumber));
                contentBuilder.AppendFormat(columnFormat, c.Number, c.Name , c.CourseType, c.Credits, ec.Grade, ec.Semester.ToString(), ec.Year, Environment.NewLine);
            }
            content = contentBuilder.ToString();

            commands = new List<PageManager.commandsEnum> { PageManager.commandsEnum.SearchStudent, PageManager.commandsEnum.MainMenu, PageManager.commandsEnum.Exit };
        }
    }
}
