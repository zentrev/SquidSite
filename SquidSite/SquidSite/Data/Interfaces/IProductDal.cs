using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Models;

namespace SquidSite.Data.Interfaces
{
    public interface IProductDal
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> Search(string Name);
        IEnumerable<Product> Search(int ID);

        bool AddProduct(Product product);
        bool DeleteProduct(int Key);
        bool DeleteProduct(Product product);
        bool EditProduct(int Key, Product product);
        Product GetProduct(int key);
    }
}
