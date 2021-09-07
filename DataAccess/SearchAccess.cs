using FatihHAS1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FatihHAS1.DataAccess
{
    public class SearchAccess
    {
        SqlConnection connString = new SqlConnection("Data Source=FATIHAS-IS\\SQLEXPRESS;initial catalog=FatihHAS;integrated security=true");       
        Product objUrun = new Product();
        DataSet dataSet = new DataSet();
        List<Product> urunList = new List<Product>();
        public List<Product> Search(Product pro)
        {
            List<Product> liste = new List<Product>();
            using (SqlConnection connString = new SqlConnection("Data Source=FATIHAS-IS\\SQLEXPRESS;initial catalog=FatihHAS;integrated security=true"))
            {
                connString.Open();
                SqlCommand cmd = new SqlCommand("SysProductList", connString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchPro", pro);
                SqlDataAdapter dataAdapt = new SqlDataAdapter(cmd);
                dataAdapt.Fill(dataSet);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    objUrun.ProductId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ProductId"]); //show records with selected columns  
                    objUrun.ProductName = dataSet.Tables[0].Rows[i]["ProductName"].ToString();
                    objUrun.ProductStok = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ProductStok"]);
                    objUrun.ProductDescription = dataSet.Tables[0].Rows[i]["ProductDescription"].ToString();
                    urunList.Add(objUrun);
                }
            }
            objUrun.productInfo = urunList;
            return urunList;
        }       
    }
}