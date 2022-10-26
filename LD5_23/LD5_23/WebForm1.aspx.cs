using System;
using LD5_23.Code;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD5_23
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Order order;
            List<Product> products;
            try
            {
                products = InOutUtils.ReadProductsDir(Server.MapPath("App_Data"), "DataFile*.txt");
                order = InOutUtils.ReadOrder(Server.MapPath("App_Data/Order.txt"));
            }
            catch (Exception exception)
            {
                ErrorLabel1.Text = exception.Message;
                return;
            }

            using (var writer = new ResultsWriter(Server.MapPath("App_Data/Rezultatai.txt"), ResultsDiv))
            {
                writer.WriteLine("Sandeliai:");
                InOutUtils.PrintProduct(writer, products);

                writer.WriteLine("Užsakymas:");
                InOutUtils.PrintOrder(writer, order);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Order order;
            List<Product> products;
            try
            {
                products = InOutUtils.ReadProductsDir(Server.MapPath("App_Data"), "DataFile*.txt");
                order = InOutUtils.ReadOrder(Server.MapPath("App_Data/Order.txt"));
            }
            catch (Exception exception)
            {
                ErrorLabel1.Text = exception.Message;
                return;
            }

            int Sum = Convert.ToInt32(TextBox1.Text);

            int runningAmount = 0;
            decimal runningSum = 0;

            var filteredProducts = products
                .Where(product => order.Name.Equals(product.Name))
                .Where(product => order.PriceLimit > product.Price)
                .OrderBy(product => product.Price)
                .TakeWhile(product =>
                {
                    if (runningAmount == order.Amount) return false;

                    int leftover = order.Amount - runningAmount;

                    if (leftover < product.Amount) product.Amount = leftover;

                    runningAmount += product.Amount;

                    return runningAmount <= order.Amount;
                }).ToList();

            var totalPrice = filteredProducts
                .Select(product => product.Price * product.Amount)
                .Sum();

            var filteredByPrice = new List<Product>();
            foreach (var filteredProduct in filteredProducts)
            {
                Product product = new Product(filteredProduct.WarehouseID, filteredProduct.Name, filteredProduct.Amount, filteredProduct.Price);
                filteredByPrice.Add(product);
            }
            if (totalPrice > Sum)
            {
                filteredByPrice = filteredByPrice
                    .TakeWhile(product =>
                    {
                        decimal leftover = Sum - runningSum;
                        decimal fullPrice = product.Amount * product.Price;

                        if (leftover < product.Price) return false;

                        if (runningSum == Sum) return false;

                        if (leftover < fullPrice)
                        {
                            int amount = (int)(leftover / product.Price);
                            product.Amount = amount;
                        }
                        runningSum += product.Amount * product.Price;
                        return runningSum <= Sum;
                    })
                    .ToList();
            }
            int leftoveramount = 0;
            var leftoverList = new List<Product>();
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                if (filteredProducts[i].Amount != filteredByPrice[i].Amount)
                {
                    Product product1 = null;
                    leftoveramount = filteredProducts[i].Amount - filteredByPrice[i].Amount;
                    product1 = filteredByPrice[i];
                    product1.Amount = leftoveramount;
                    leftoverList.Add(product1);
                }
            }
            using (var writer = new ResultsWriter(Server.MapPath("App_Data/Rezultatai.txt"), ResultsDiv))
            {
                writer.WriteLine("Sandeliai:");
                InOutUtils.PrintProduct(writer, products);

                writer.WriteLine("Užsakymas:");
                InOutUtils.PrintOrder(writer, order);

                writer.WriteLine("Užsakymo būsena:");
                if (runningAmount < order.Amount)
                {
                    writer.WriteLine("Sandeliuose per mažai prekių");
                }
                if (Sum < totalPrice)
                {
                    writer.WriteLine("Per brangu");
                }
                bool flag = false;
                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredByPrice[i].Amount != filteredProducts[i].Amount)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    writer.WriteLine("Netilpo į užsakyma");
                    InOutUtils.PrintProduct(writer, leftoverList);
                }
                if (!(runningAmount < order.Amount) && !(Sum < totalPrice) && !flag)
                {
                    writer.WriteLine("Užsakymas įvykdytas");
                }
            }
        }
    }
}