using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using L2_23.Code;
using System.IO;

namespace L2_23
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string inputfile = null;
        static string outputfile = null;

        /// <summary>
        /// Executes tasks on page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Destytoju priziurimu studentų skaicius nurodyta menesį (surikiuotas)";

        }

        /// <summary>
        /// Executes tasks on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            var inputfile1 = Server.MapPath(@"App_Data/U23a2.txt");
            var inputfile2 = Server.MapPath(@"App_Data/U23b2.txt");
            var outputfile = Server.MapPath(@"App_Data/Rezultatai2.txt");

            var students = InOutUtils.ReadStudents(inputfile1);
            var excersises = InOutUtils.ReadExcersises(inputfile2);
            var studentsFilteredByMonth = TaskUtils.FilterByMonth(students, TextBox1.Text);
            var countedStudents = TaskUtils.CountAssignedStudents(studentsFilteredByMonth, excersises);
            var countedStudentsFIlteredByAvr = TaskUtils.FilterProffessorsByAverage(students, excersises);
            var exercisesByProf = TaskUtils.GroupExercisesByProffesor(excersises);
            var filteredExerciseList = TaskUtils.FilterByAssignedStudents(excersises, students, Convert.ToInt32(TextBox2.Text));
            countedStudents.Sort();
            var profList = TaskUtils.GetProfName(excersises);

            using (var writer = new StreamWriter(outputfile))
            {
                InOutUtils.PrintData(writer, students);
                InOutUtils.PrintAssignedStudentCounts(writer, countedStudents);
                InOutUtils.PrintAssignedStudentCounts(writer, countedStudents);
                InOutUtils.PrintExerciseTables(writer, exercisesByProf);
                InOutUtils.PrintFilteredExerciseTables(writer, filteredExerciseList);
            }
            ShowStudentData(Table1, students);
            ShowAssignedStudentCounts(Table2, countedStudentsFIlteredByAvr);
            ShowAssignedStudentCounts(Table3, countedStudents);
            ShowProfNames(Table4, profList);
            ShowExerciseTable(tableContainer, exercisesByProf);
            ShowsFilteredExerciseTable(secondTableContainer, filteredExerciseList);
        }
    }
}