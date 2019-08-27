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

    public class UserProduct
    {
        public int UserProductID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
