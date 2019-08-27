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
                context.ProductImage.Add(new ProductImages() { Product = new Product() { Title = "TestGame", Cost = 10.11f, Description = "Testing Game", DownloadLink = "download.exe", DemoLink = "demo here", DemoDownloadLink="ima a demo download" }, ProductImage = new ProdutImage() { ImageURL = "NULL.png"} });
            }
        }
    }
}
