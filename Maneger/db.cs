using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Maneger
{
    public class db
    {
        string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Ado.net;Integrated Security=True";

        public int InsertProductsData(string connectionString)
        {
            string name, descreption, image;
            int catoryId, price;

            Console.WriteLine("insert name");
            name = Console.ReadLine();
            Console.WriteLine("insert category Id");
            catoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert price");
            price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("insert descreption");
            descreption = Console.ReadLine();
            Console.WriteLine("insert image");
            image = Console.ReadLine();

            string Query = "INSERT INTO Products(name, descreption, image,catoryId , price )" +
                "VALUES(@name, @descreption, @image,@catoryId , @price )";

            using (SqlConnection connaction = new SqlConnection(connectionString))
            using(SqlCommand command = new SqlCommand(Query, connaction))
            {
                command.Parameters.Add("@name", SqlDbType.VarChar,50).Value=name;
                command.Parameters.Add("@descreption", SqlDbType.VarChar, 200).Value=descreption;
                command.Parameters.Add("@image", SqlDbType.VarChar, 50).Value=image;
                command.Parameters.Add("@catoryId", SqlDbType.Int).Value=catoryId;
                command.Parameters.Add("@price", SqlDbType.Int).Value=price;


                connaction.Open();
                int rowsEfected = command.ExecuteNonQuery();
                connaction.Close();
                return rowsEfected;
            }

        }
        public int InsertCategoriesData(string connectionString)
        {
            string name;
            Console.WriteLine("insert name");
            name = Console.ReadLine();

            string Query = "INSERT INTO Categoies(name)" +
                "VALUES(@name)";
            using (SqlConnection connaction = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(Query, connaction))
            {
                command.Parameters.Add("@name", SqlDbType.VarChar, 50).Value=name;
                connaction.Open();
                int rowsEfected = command.ExecuteNonQuery();
                return rowsEfected;
            }

        }
    public void ReadPData(string connectionString)
        {
            string Query = "SELECT * FROM Products p join Categoies c on p.catoryId= c.id  ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader =  command.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine("\t{0} \t{1} \t{2} \t{3} \t{4} \t{5}", reader[0]
                            , reader[1], reader[2], reader[3], reader[4], reader[5]);
                        
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }

        }


        public void ReadCData(string connectionString)
        {
            string Query = "SELECT * FROM Categoies";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0} \t{1} ", reader[0], reader[1]);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }

        }
    }
}
