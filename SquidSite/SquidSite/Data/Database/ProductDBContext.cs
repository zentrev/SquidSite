using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Data.Interfaces;
using SquidSite.Models;
using Microsoft.EntityFrameworkCore;

namespace SquidSite.Data.Database
{
    public class ProductDBContext : IProductDal
    {

        private readonly SquidSiteDbContext _context;

        public ProductDBContext(SquidSiteDbContext context)
        {
            _context = context;
        }

        public bool AddProduct(Product product)
        {
            _context.Products.Add(product);
            return true;
        }

        public bool DeleteProduct(int Key)
        {
            return DeleteProduct(GetProduct(Key));
        }

        public bool DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return true;
        }

        public bool EditProduct(int Key, Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include("ImageURLS.ProductImage").ToList();
        }

        public Product GetProduct(int key)
        {
            return GetAll().FirstOrDefault(p => p.ProductID == key);
        }

        public IEnumerable<Product> Search(string Name)
        {
            return GetAll().Where(p => p.Title.Contains(Name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Product> Search(int ID)
        {
            return GetAll().Where(p => p.ProductID.ToString().Contains(ID.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
