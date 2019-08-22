using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class ProdutImage
    {
        public int ProdutImageID { get; set; }
        public string ImageURL { get; set; }
        public Product Product { get; set; }
    }
}
