using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            #region Insert a Record

            //context.Departments.Add(new Department { Name = "Open Source" });

            //context.SaveChanges(); 
            #endregion

            foreach (var dept in context.Departments)
            {
                Console.WriteLine(dept.Name);
            }

        }
    }
}
