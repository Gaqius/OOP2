using System;
using System.Collections.Generic;
using L4_23.Code;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L4_23
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            const string CFd1 = "JuvelryData1.txt";
            const string CFd2 = "JuvelryData2.txt";
            const string csv1 = "Visur.csv";
            const string csv2 = "Brangus.csv";

            var juvleries = InOutUtils.ReadJuvelryDir(Server.MapPath("App_Data"));
            var names = juvleries.Select(j => j.ShopName).Distinct().ToList();
            var shopname1 = names[0];
            var shopname2 = names[1];

            PrintStartData(Table1, juvleries);
            PrintHeaviest(Table2, juvleries);
            PrintHighestCarat(Label3, juvleries, shopname1);
            PrintHighestCarat(Label5, juvleries, shopname2);
        }
    }
}