using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD_23
{
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<List<int>> part = new List<List<int>> { new List<int> {1, 2, 3, 4 }, new List<int> { 2, 3}, new List<int> { 3, 1, 4, 2}, new List<int> { 4, 2} };

            for (int i = 0; i <= part.Count; i++)
            {
                part[i].Sort();
            }

        }
    }
}