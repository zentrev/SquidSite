using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Data.Database;
using SquidSite.Models;

namespace SquidSite.Data
{
    public class DummyInit
    {
        public static void Seed(SquidSiteDbContext context)
        {
            if (!context.Products.Any())
            {
                context.ProductImage.Add(new ProductImages() { Product = new Product() { Title = "TestGame", Cost = 10.11f, Description = "Testing Game", DownloadLink = "download.exe", DemoLink = "demo here", DemoDownloadLink="ima a demo download", ProductType = Product.eProductType.GAME }, ProductImage = new ProdutImage() { ImageURL = "NULL.png"} });
                context.ProductImage.Add(new ProductImages() { Product = new Product() { Title = "TestGame2", Cost = 10.91f, Description = "Testing Game2", DownloadLink = "download.exe", DemoLink = "demo here", ProductType = Product.eProductType.GAME }, ProductImage = new ProdutImage() { ImageURL = "NULL.png"} });
                context.ProductImage.Add(new ProductImages() { Product = new Product() { Title = "TestGame3", Cost = 14.11f, Description = "Testing Game3", DownloadLink = "download.exe", ProductType = Product.eProductType.GAME }, ProductImage = new ProdutImage() { ImageURL = "NULL.png"} });
                context.ProductImage.Add(new ProductImages() { Product = new Product() { Title = "Cool Socks", Cost = 36.99f, Description = "some really cool knited socks", MerchTags=Product.eMerchTags.SOCKS, ProductType = Product.eProductType.MERCH }, ProductImage = new ProdutImage() { ImageURL = "NULL.png"} });
            }
        }
    }
}
