using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Manager
{
    internal class Products
    {
      public int  InsertProduct (string connectionString)
        {
            int categoryId;
            string name, descrption, price, image,c;
            Console.WriteLine("enter product name");
            name = Console.ReadLine();
            Console.WriteLine("enter product descrption");
            descrption = Console.ReadLine();
            Console.WriteLine("enter product price");
            price = Console.ReadLine();
            Console.WriteLine("enter product image");
            image = Console.ReadLine();
            Console.WriteLine("enter product categoryId");
            categoryId =int.Parse(Console.ReadLine());
            string query = "INSERT INTO Product(categoryId,productName,price,image,descraptionProduct)" +
                "VALUES(@categoryId,@productName,@price,@image,@descraptionProduct)";
            using (SqlConnection cn = new SqlConnection(connectionString)) 
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@productName", SqlDbType.NVarChar, 50).Value = name;
                cmd.Parameters.Add("@price", SqlDbType.NVarChar, 50).Value = price;
                cmd.Parameters.Add("@image", SqlDbType.NVarChar, 50).Value = image;
                cmd.Parameters.Add("@descraptionProduct", SqlDbType.NVarChar, 100).Value = descrption;
                cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                cn.Open();
                int rowAffacted = cmd.ExecuteNonQuery();
                cn.Close();
                Console.WriteLine("do you want to continue y/n");
                c = Console.ReadLine();
                if (c=="y")
                {
                    InsertProduct(connectionString);
                }
                return rowAffacted;
                
            }
            


        }
    public void GetAllProduct(string connectionString)
        {
            string query = "select * from Product";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    cn.Open();
                    SqlDataReader products = cmd.ExecuteReader();
                    while (products.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", products[0], products[1], products[2], products[3], products[4], products[5]);
                    }
                    products.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                Console.ReadLine();


            }



        }

    }
}
