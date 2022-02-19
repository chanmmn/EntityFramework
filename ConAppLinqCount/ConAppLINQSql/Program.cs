using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppLINQSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Count1();
            Count2();
        }

        public static void AdoNet()
        {

            //System.Configuration.ConnectionStringSettings connsetting;
            //connsetting = cf.ConnectionStrings.ConnectionStrings["IPMSConnectionString"];

            string strconn = System.Configuration.ConfigurationManager.ConnectionStrings["SchoolDBAdo"].ConnectionString;
            string strcmd = "SELECT * FROM Student";
 
            SqlConnection connection = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand(strcmd, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
        }
        
        public static void Count1()
        {
            using (var context = new SchoolDBEntities())
            {
                Console.WriteLine("Select all then Count but with lazy loading it will be issuing the COUNT function in SQL");
                context.Database.Log = Console.WriteLine;
                var student = context.Students;    
                int count = student.Count();
                Console.WriteLine("------------------------------------------");
            }
        }
       
        public static void Count2()
        {
            using (var context = new SchoolDBEntities())
            {
                Console.WriteLine("The function issue the COUNT function with a single statement");
                context.Database.Log = Console.WriteLine;
                int count = context.Standards.Count();
                Console.WriteLine();
            }
        }
    }
}
