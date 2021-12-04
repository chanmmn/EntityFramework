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
            //Loading();
            Loading1();
            //Loading2(); 
            //AdoNet();
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
        
        public static void Loading()
        {

            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.WriteLine;
                Student student = context.Students.Where(s => s.StudentID == 1).FirstOrDefault<Student>();                
            }
        }

        public static void Loading1()
        {

            using (var context = new SchoolDBEntities())
            {
                var students = from r in context.Students where (r.StudentID == 1) select r;
                string SqlQuery = students.ToString();
                Console.WriteLine(SqlQuery);
            }
        }

        public static void Loading2()
        {
            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.WriteLine;
                var students = from r in context.Students where (r.StudentID == 1) select r;
                Console.WriteLine(students.FirstOrDefault().StudentName);
            }
        }
    }
}
