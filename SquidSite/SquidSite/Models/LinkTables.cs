using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class ProductImages
    {
        public int ProductImagesID { get; set; }
        public int ProdcutID;
        public Product Product;
        public int ProductImageID;
        public ProdutImage ProductImage;
    }
}
