using FatihHAS1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FatihHAS1.DataAccess
{
    public class ProductEdit
    {
        public List<Product> ListAll()
        {
            List<Product> liste = new List<Product>();
            using (SqlConnection connString = new SqlConnection("Data Source=FATIHAS-IS\\SQLEXPRESS;initial catalog=FatihHAS;integrated security=true"))
            {
                connString.Open();
                SqlCommand cmd = new SqlCommand("SysProductList", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataRead = cmd.ExecuteReader();
                while (dataRead.Read())
                {
                    liste.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dataRead["ProductId"]),
                        ProductName = dataRead["ProductName"].ToString(),
                        ProductStok = Convert.ToInt32(dataRead["ProductStok"]),
                        ProductDescription = dataRead["ProductDescription"].ToString(),
                    });
                }
                return liste;
            }
        }
        public int ProductAdd(Product pro)
        {
            int i = 0;
            using (SqlConnection connString = new SqlConnection("Data Source=FATIHAS-IS\\SQLEXPRESS;initial catalog=FatihHAS;integrated security=true"))
            {
                connString.Open();
                SqlCommand cmd = new SqlCommand("SysProduct", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", pro.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
                cmd.Parameters.AddWithValue("@ProductStok", pro.ProductStok);
                cmd.Parameters.AddWithValue("@ProductDes", pro.ProductDescription);
                cmd.Parameters.AddWithValue("@Action", "Insert");
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
        public int ProductUpdate(Product pro)
        {
            int i = 0;
            using (SqlConnection connString = new SqlConnection("Data Source=FATIHAS-IS\\SQLEXPRESS;initial catalog=FatihHAS;integrated security=true"))
            {
                connString.Open();
                SqlCommand cmd = new SqlCommand("SysProduct", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", pro.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", pro.ProductName);
                cmd.Parameters.AddWithValue("@ProductStok", pro.ProductStok);
                cmd.Parameters.AddWithValue("@ProductDes", pro.ProductDescription);
                cmd.Parameters.AddWithValue("@Action", "Update");
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }
    }
}