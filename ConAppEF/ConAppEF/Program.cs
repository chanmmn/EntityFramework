using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppEF
{
    class Program
    {
        static void Main(string[] args)
        {
            pocEntities ctx = new pocEntities();
            var studentList = from r in ctx.Students select r;
            var standardList = from r in ctx.Standards select r;

            var innerJoin = studentList.Join(// outer sequence 
                      standardList,  // inner sequence 
                      student => student.StandardID,    // outerKeySelector
                      standard => standard.StandardID,  // innerKeySelector
                      (student, standard) => new  // result selector
                      {
                          StudentName = student.StudentName,
                          StandardName = standard.StandardName
                      });

            foreach (var data in innerJoin)
            {
                Console.WriteLine(data.StandardName);
                Console.WriteLine(data.StudentName);
            }
        }
    }
}
