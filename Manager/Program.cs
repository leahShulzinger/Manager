﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "data source=srv2\\pupils;initial catalog=MyShop_328120357;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=true";
            Products p = new Products();
           int row= p.InsertProduct(connectionString);
            p.GetAllProduct(connectionString);
           
        }
    }
}
