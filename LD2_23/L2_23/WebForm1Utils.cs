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
        /// <summary>
        /// Outputs student data
        /// </summary>
        /// <param name="table"></param>
        /// <param name="students"></param>
       public void ShowStudentData(Table table, ObjectList students)
        {
            TableRow headerRow = new TableRow();

            if (students.Count() == 0)
            {

                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                table.Rows.Add(headerRow);

                return;
            }

            headerRow.Cells.Add(new TableCell {Text = "Pavardė" });
            headerRow.Cells.Add(new TableCell { Text = "Vardas" });
            headerRow.Cells.Add(new TableCell { Text = "Grupė" });
            headerRow.Cells.Add(new TableCell { Text = "mėnuo" });
            headerRow.Cells.Add(new TableCell { Text = "Užduoties kodas" });

            table.Rows.Add(headerRow);

            foreach (Student student in students)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = student.Surname});
                row.Cells.Add(new TableCell { Text = student.Name });
                row.Cells.Add(new TableCell { Text = student.Group });
                row.Cells.Add(new TableCell { Text = student.Month });
                row.Cells.Add(new TableCell { Text = student.ExcersiseID });

                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Shows assigned students
        /// </summary>
        /// <param name="table"></param>
        /// <param name="counts"></param>
       public void ShowAssignedStudentCounts(Table table, ObjectList counts)
        {
            TableRow headerRow = new TableRow();

            if (counts.Count() == 0)
            {

                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                table.Rows.Add(headerRow);

                return;
            }

            headerRow.Cells.Add(new TableCell { Text = "Dėstytojas" });
            headerRow.Cells.Add(new TableCell { Text = "Kiekis" });

            table.Rows.Add(headerRow);

            foreach (TupleStringInt count in counts)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = count.Item1 });
                row.Cells.Add(new TableCell { Text = Convert.ToString(count.Item2) });

                table.Rows.Add(row);
            }
        }
        static void ShowProfNames(Table table, ObjectList profNames)
        {
            TableRow headerRow = new TableRow();

            if (profNames.Count() == 0)
            {

                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                table.Rows.Add(headerRow);
                return;
            }

            headerRow.Cells.Add(new TableCell { Text = "Dėstytojas" });

            table.Rows.Add(headerRow);

            foreach (string profName in profNames)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = profName });

                table.Rows.Add(row);
            }
        }
        /// <summary>
        /// Shows exercises
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        public void ShowExerciseTable(Control container, Dictionary<string, ObjectList> list)
        {
            if (list.Count() == 0)
            {
                TableRow headerRow = new TableRow();
                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                Table table = new Table();

                container.Controls.Add(table);

                table.Rows.Add(headerRow);
                return;
            }
            foreach (var item in list)
            {
                Table table = new Table();

                container.Controls.Add(table);

                TableRow headerRow = new TableRow();

                headerRow.Cells.Add(new TableCell { Text = "Užduoties kodas" });
                headerRow.Cells.Add(new TableCell { Text = "Užduoties pavadinimas" });
                headerRow.Cells.Add(new TableCell { Text = "Dėstytojas" });
                headerRow.Cells.Add(new TableCell { Text = "Skirtas laikas" });

                table.Rows.Add(headerRow);

                foreach (Excersise exercise in item.Value)
                {
                    TableRow row = new TableRow();

                    row.Cells.Add(new TableCell { Text = exercise.ID });
                    row.Cells.Add(new TableCell { Text = exercise.Name });
                    row.Cells.Add(new TableCell { Text = exercise.ProfNameSurname });
                    row.Cells.Add(new TableCell { Text = Convert.ToString(exercise.TimeLimit) });

                    table.Rows.Add(row);
                }
            }
        }
        /// <summary>
        /// Shows filtered exercises
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        public void ShowsFilteredExerciseTable(Control container, ObjectList list)
        {
            if (list.Count() == 0)
            {
                TableRow headerRow = new TableRow();
                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                Table table = new Table();

                container.Controls.Add(table);

                table.Rows.Add(headerRow);

                return;
            }
            foreach (ObjectList item in list)
            {
                Table table = new Table();

                container.Controls.Add(table);

                TableRow headerRow = new TableRow();

                headerRow.Cells.Add(new TableCell { Text = "Užduoties kodas" });
                headerRow.Cells.Add(new TableCell { Text = "Užduoties pavadinimas" });
                headerRow.Cells.Add(new TableCell { Text = "Dėstytojas" });
                headerRow.Cells.Add(new TableCell { Text = "Skirtas laikas" });

                table.Rows.Add(headerRow);

                foreach (Excersise exercise in item)
                {
                    TableRow row = new TableRow();

                    row.Cells.Add(new TableCell { Text = exercise.ID });
                    row.Cells.Add(new TableCell { Text = exercise.Name });
                    row.Cells.Add(new TableCell { Text = exercise.ProfNameSurname });
                    row.Cells.Add(new TableCell { Text = Convert.ToString(exercise.TimeLimit) });

                    table.Rows.Add(row);
                }
            }
        }
    }
}