using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maneger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Ado.net;Integrated Security=True";
            Console.WriteLine("hello to our project");

            db db = new db();
            int res1 = 0,res2=0;
            string YN="y" ;

            while (YN == "y")
            {
                res1 = +db.InsertCategoriesData(connectionString);
                Console.WriteLine("if you want to continue press y/n");
                YN = Console.ReadLine();

            }
            YN = "y";
            Console.WriteLine(res1 + "rowes efected");
            while (YN == "y")
            {
                res2 = +db.InsertProductsData(connectionString);
                Console.WriteLine("if you want to continue press y/n");
                YN = Console.ReadLine();

            }

            Console.WriteLine(res2 + "rowes efected");
            //db.ReadCData(connectionString);
            db.ReadPData(connectionString);
            db.ReadCData(connectionString);
        }
    }
}
