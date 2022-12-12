using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsAppEF2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://stackoverflow.com/questions/41933985/how-to-join-3-tables-with-linq
            LINQDist();


        }

        public static void Join3Tables()
        {
            NorthwindEntities1 ctx = new NorthwindEntities1();

            var prodlst = ctx.Products;
            var ordlst = ctx.Orders;
            var orderDetail = ctx.Order_Details;

            //https://stackoverflow.com/questions/41933985/how-to-join-3-tables-with-linq

            var result = from d in prodlst
                         join c in orderDetail on d.ProductID equals c.ProductID
                         join s in ordlst on c.OrderID equals s.OrderID
                         select new
                         {
                             //duty = s.Duty.Duty,
                             //CatId = s.Company.CompanyName,
                             //SewagePlantName = s.SewagePlant.SewagePlantName
                             // other assignments
                             proname = d.ProductName,
                             productID = d.ProductID,
                             orderID = s.OrderID
                         };

            foreach(var item in result)
            {
                Console.WriteLine("{0}\t{1},\t{2}",item.proname, item.productID, item.orderID);
            }
        }

        public static void LINQDist()
        {
            NorthwindEntities1 ctx = new NorthwindEntities1();

            var prodlst = ctx.Products;
            var ordlst = ctx.Orders;
            var orderDetail = ctx.Order_Details;

            var result = from d in prodlst
                         join c in orderDetail on d.ProductID equals c.ProductID
                         join s in ordlst on c.OrderID equals s.OrderID
                         select new
                         {
                             //duty = s.Duty.Duty,
                             //CatId = s.Company.CompanyName,
                             //SewagePlantName = s.SewagePlant.SewagePlantName
                             // other assignments
                             proname = d.ProductName,
                             productID = d.ProductID,
                             orderID = s.OrderID
                         };
            var dist = result.ToList();
            var lst = dist
                    .Select(std => std.proname)
                    .Distinct().ToList();

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
        }

        public static void LINQGroup()
        {
            NorthwindEntities1 ctx = new NorthwindEntities1();

            var prodlst = ctx.Products;
            var ordlst = ctx.Orders;
            var orderDetail = ctx.Order_Details;

            var query = (from d in prodlst
                         join c in orderDetail on d.ProductID equals c.ProductID
                         join s in ordlst on c.OrderID equals s.OrderID
                         group d by new { d.ProductID, d.ProductName, s.OrderID }
                into grp
                         select new
                         {
                             grp.Key.ProductID,
                             grp.Key.ProductName,
                             grp.Key.OrderID
                         }).ToList();

            foreach (var item in query)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
