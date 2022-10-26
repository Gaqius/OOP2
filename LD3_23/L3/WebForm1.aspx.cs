using System;
using System.IO;
using L3.Code;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Executes tasks on page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Executes tasks on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            var outputfile = Server.MapPath(@"App_Data/Rezultatai2.txt");

            var students = InOutUtils.ReadStudents(FileUpload1.FileContent);
            var excersises = InOutUtils.ReadExcersises(FileUpload2.FileContent);
            var studentsFilteredByMonth = TaskUtils.FilterByMonth(students, TextBox1.Text);
            var countedStudents = TaskUtils.CountAssignedStudents(studentsFilteredByMonth, excersises);
            var countedStudentsFIlteredByAvr = TaskUtils.FilterProffessorsByAverage(students, excersises);
            var filteredExerciseList = TaskUtils.FilterByAssignedStudents(excersises, students, Convert.ToInt32(TextBox2.Text));
            countedStudents.Sort();
            var profList = TaskUtils.GetProfName(excersises);

            using (var writer = new StreamWriter(outputfile))
            {
                InOutUtils.PrintData(writer, students);
                InOutUtils.PrintAssignedStudentCounts(writer, countedStudents);
                InOutUtils.PrintAssignedStudentCounts(writer, countedStudents);
                InOutUtils.PrintExerciseTables(writer, excersises);
                InOutUtils.PrintFilteredExerciseTables(writer, filteredExerciseList);
            }
            ShowStudentData(Table1, students);
            ShowAssignedStudentCounts(Table2, countedStudentsFIlteredByAvr);
            ShowAssignedStudentCounts(Table3, countedStudents);
            ShowProfNames(Table4, profList);
            ShowExerciseTable(tableContainer, excersises);
            ShowsFilteredExerciseTable(secondTableContainer, filteredExerciseList);
        }
    }
}