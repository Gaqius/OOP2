using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD5_23.Code
{
    /// <summary>
    /// A helper class for writing result files
    /// </summary>
    public class ResultsWriter : IDisposable
    {
        private readonly StreamWriter FileWriter;
        private readonly Control ResultDiv;

        public ResultsWriter(string resultFilename, Control resultDiv)
        {
            FileWriter = new StreamWriter(resultFilename, false, Encoding.UTF8);
            ResultDiv = resultDiv;
        }
        /// <summary>
        /// Write a line to the result outputs
        /// </summary>
        /// <param name="line"></param>
        public void WriteLine(string line)
        {
            FileWriter.WriteLine(line);
            ResultDiv.Controls.Add(new Label { Text = line + "<br />" });
        }
        /// <summary>
        /// Writes an empty line
        /// </summary>
        public void WriteLine()
        {
            WriteLine("");
        }
        /// <summary>
        /// Write a table to the web
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        private void WriteWebTable(List<List<string>> rows, params string[] columns)
        {
            Table table = new Table();
            ResultDiv.Controls.Add(table);

            TableHeaderRow headerRow = new TableHeaderRow();
            foreach (string column in columns)
            {
                headerRow.Cells.Add(new TableHeaderCell { Text = column });
            }
            table.Rows.Add(headerRow);

            if (rows.Count == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = "Nėra", ColumnSpan = columns.Length });
                table.Rows.Add(row);
            }
            else
            {
                foreach (var row in rows)
                {
                    TableRow tableRow = new TableRow();
                    var cells = row.Select(Text => new TableCell { Text = Text }).ToArray();
                    tableRow.Cells.AddRange(cells);
                    table.Rows.Add(tableRow);
                }
            }
        }
        /// <summary>
        /// Print a single row of values in a table format to file
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="widths"></param>
        private void PrintTableRow(IList<string> cells, List<int> widths)
        {
            for (int i = 0; i < widths.Count; i++)
            {
                FileWriter.Write("| {0} ", cells[i].PadRight(widths[i]));
            }
            FileWriter.WriteLine("|");
        }
        /// <summary>
        /// Calculate the minimum required widths for each column
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private static List<int> FindTableWidths(List<List<string>> rows, string[] columns)
        {
            List<int> widths = new List<int>();
            int totalWidth = 3 * (columns.Length - 1);
            for (int i = 0; i < columns.Length; i++)
            {
                int width = columns[i].Length;
                foreach (var row in rows)
                {
                    width = Math.Max(row[i].Length, width);
                }
                widths.Add(width);
                totalWidth += width;
            }

            return widths;
        }
        /// <summary>
        /// Write a table to file
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        private void WriteFileTable(List<List<string>> rows, params string[] columns)
        {
            var widths = FindTableWidths(rows, columns);
            int totalWidth = 3 * (columns.Length - 1) + 2 * 2 + widths.Sum();

            FileWriter.WriteLine(new string('-', totalWidth));
            PrintTableRow(columns, widths);
            FileWriter.WriteLine(new string('-', totalWidth));
            if (rows.Count > 0)
            {
                foreach (var row in rows)
                {
                    PrintTableRow(row, widths);
                }
            }
            else
            {
                FileWriter.WriteLine("| {0} |", "Nėra".PadRight(totalWidth - 4));
            }
            FileWriter.WriteLine(new string('-', totalWidth));
        }
        /// <summary>
        /// Writes a table to the WEB and file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public IEnumerable<Tuple<T, List<object>>> WriteTable<T>(IEnumerable<T> items, params string[] columns)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (var item in items)
            {
                List<object> row = new List<object>();
                yield return Tuple.Create(item, row);
                rows.Add(row.Select(x => x.ToString()).ToList());
            }

            WriteWebTable(rows, columns);
            WriteFileTable(rows, columns);
            WriteLine();
        }
        /// <summary>
        /// Write a bulleted list to the file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        private void WriteFileList<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                FileWriter.WriteLine("* {0}", item);
            }
        }
        /// <summary>
        /// Write a bulleted list to the web
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        private void WriteWebList<T>(IEnumerable<T> items)
        {
            var list = new BulletedList();
            ResultDiv.Controls.Add(list);
            foreach (var item in items)
            {
                list.Items.Add(item.ToString());
            }
        }
        /// <summary>
        /// Write a bulleted list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public void WriteList<T>(IEnumerable<T> items)
        {
            if (items.Any())
            {
                WriteFileList(items);
                WriteWebList(items);
            }
            else
            {
                WriteLine("Nėra");
            }
            WriteLine();
        }
        public void Dispose()
        {
            FileWriter.Dispose();
        }
    }
}