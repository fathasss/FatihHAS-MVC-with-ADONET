using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FatihHAS1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStok { get; set; }
        public string ProductDescription { get; set; }
        public List<Product> productInfo { get; set; }

    }
}