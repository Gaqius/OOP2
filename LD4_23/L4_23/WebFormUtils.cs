using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
using L4_23.Code;

namespace L4_23
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// Prints Starting Data To Screen
        /// </summary>
        /// <param name="table"></param>
        /// <param name="juvelries"></param>
        static void PrintStartData(Table table, List<Juvelry> juvelries)
        {
            TableRow headerRow = new TableRow();

            if (juvelries.Count == 0)
            {
                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                table.Rows.Add(headerRow);
                return;
            }

            headerRow.Cells.Add(new TableCell { Text = "Parduotuvės pavadinimas" });
            headerRow.Cells.Add(new TableCell { Text = "Adresas" });
            headerRow.Cells.Add(new TableCell { Text = "Telefonas" });
            headerRow.Cells.Add(new TableCell { Text = "Gamintojas" });
            headerRow.Cells.Add(new TableCell { Text = "Pavadinimas" });
            headerRow.Cells.Add(new TableCell { Text = "Metalas" });
            headerRow.Cells.Add(new TableCell { Text = "Svoris" });
            headerRow.Cells.Add(new TableCell { Text = "Praba" });
            headerRow.Cells.Add(new TableCell { Text = "Kaina" });
            for (int i = 0; i < juvelries.Count; i++)
            {
                if (juvelries[i] is Ring)
                {
                    headerRow.Cells.Add(new TableCell { Text = "Dydis" });
                }
                else if (juvelries[i] is Earrings)
                {
                    headerRow.Cells.Add(new TableCell { Text = "Užsegimo tipas" });
                }
                else if (juvelries[i] is Chain)
                {
                    headerRow.Cells.Add(new TableCell { Text = "Ilgis" });
                }
            }
            table.Rows.Add(headerRow);

            foreach (var item in juvelries)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = item.ShopName});
                row.Cells.Add(new TableCell { Text = item.Adress});
                row.Cells.Add(new TableCell { Text = item.PhoneNumber });
                row.Cells.Add(new TableCell { Text = item.Maker });
                row.Cells.Add(new TableCell { Text = item.Name });
                row.Cells.Add(new TableCell { Text = item.Metal });
                row.Cells.Add(new TableCell { Text = item.Weight.ToString() });
                row.Cells.Add(new TableCell { Text = item.Carat.ToString() });
                row.Cells.Add(new TableCell { Text = item.Price.ToString() });
                if (item is Ring)
                {
                    row.Cells.Add(new TableCell { Text = (item as Ring).size.ToString() });
                }
                else if (item is Earrings)
                {
                    row.Cells.Add(new TableCell { Text = (item as Earrings).ClaspType });
                }
                else if (item is Chain)
                {
                    row.Cells.Add(new TableCell { Text = (item as Chain).Lenght.ToString() });
                }                
            }
        }
        /// <summary>
        /// Prints Heaviest Juveleries to the Screen
        /// </summary>
        /// <param name="table"></param>
        /// <param name="juvelries"></param>
        static void PrintHeaviest(Table table, List<Juvelry> Juvs)
        {
            var juvelries = TaskUtils.FindHeaviest(Juvs);
            TableRow headerRow = new TableRow();

            if (juvelries.Count == 0)
            {
                headerRow.Cells.Add(new TableCell { Text = "Tuščia" });

                table.Rows.Add(headerRow);
                return;
            }
            headerRow.Cells.Add(new TableCell { Text = "Parduotuvės pavadinimas" });
            headerRow.Cells.Add(new TableCell { Text = "Adresas" });
            headerRow.Cells.Add(new TableCell { Text = "Telefonas" });
            headerRow.Cells.Add(new TableCell { Text = "Gamintojas" });
            headerRow.Cells.Add(new TableCell { Text = "Pavadinimas" });
            headerRow.Cells.Add(new TableCell { Text = "Metalas" });
            headerRow.Cells.Add(new TableCell { Text = "Svoris" });
            headerRow.Cells.Add(new TableCell { Text = "Praba" });
            headerRow.Cells.Add(new TableCell { Text = "Kaina" });
            for (int i = 0; i < juvelries.Count; i++)
            {
                if (juvelries[i] is Ring)
                {
                    headerRow.Cells.Add(new TableCell { Text = "Dydis" });
                }
                else if (juvelries[i] is Earrings)
                {
                    headerRow.Cells.Add(new TableCell { Text = "Užsegimo tipas" });
                }
                else if (juvelries[i] is Chain)
                {
                    headerRow.Cells.Add(new TableCell { Text = "Ilgis" });
                }
            }
            table.Rows.Add(headerRow);

            foreach (var item in juvelries)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = item.ShopName });
                row.Cells.Add(new TableCell { Text = item.Adress });
                row.Cells.Add(new TableCell { Text = item.PhoneNumber });
                row.Cells.Add(new TableCell { Text = item.Maker });
                row.Cells.Add(new TableCell { Text = item.Name });
                row.Cells.Add(new TableCell { Text = item.Metal });
                row.Cells.Add(new TableCell { Text = item.Weight.ToString() });
                row.Cells.Add(new TableCell { Text = item.Carat.ToString() });
                row.Cells.Add(new TableCell { Text = item.Price.ToString() });
                if (item is Ring)
                {
                    row.Cells.Add(new TableCell { Text = (item as Ring).size.ToString() });
                }
                else if (item is Earrings)
                {
                    row.Cells.Add(new TableCell { Text = (item as Earrings).ClaspType });
                }
                else if (item is Chain)
                {
                    row.Cells.Add(new TableCell { Text = (item as Chain).Lenght.ToString() });
                }
            }
        }
        /// <summary>
        /// Prints Highest Carat Juvelry to Screen
        /// </summary>
        /// <param name="label"></param>
        /// <param name="juvelries"></param>
        /// <param name="shopName"></param>
        static void PrintHighestCarat(Label label, List<Juvelry> juvelries, string shopName)
        {
            label.Text = TaskUtils.FindHighestCaratAtStore(juvelries, shopName).ToString();
        }
        /// <summary>
        /// Prints Juvelry Thats In Every Store to CSV File
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="juvelries"></param>
        static void PrintEverywhereToCsv(string filename, List<Juvelry> juvelries)
        {
            using (var writer = new StreamWriter(filename, true, Encoding.UTF8))
            {
                var Filtered = TaskUtils.IsInBothStores(juvelries);
                if (juvelries.Count == 0)
                {
                    writer.WriteLine("Tuščia");
                    return;
                }
                foreach (var juvelry in Filtered)
                {
                    writer.WriteLine(juvelry.ToCSVLine());
                }
            }                
        }
        /// <summary>
        /// Prints Expensive Juvelry to CSV File
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="juvelries"></param>
        static void PrintExpensiveToCsv(string filename, List<Juvelry> juvelries)
        {
            using (var writer = new StreamWriter(filename, true, Encoding.UTF8))
            {
                var Filtered = TaskUtils.FindExpensive(juvelries);
                if (juvelries.Count == 0)
                {
                    writer.WriteLine("Tuščia");
                    return;
                }
                foreach (var juvelry in Filtered)
                {
                    writer.WriteLine(juvelry.ToCSVLine());
                }
            }
        }
    }
}