using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public List<ProdutImage> ImageURLS { get; set; }
    }
}
