using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Models;

namespace SquidSite.Data.Interfaces
{
    interface IMerchDal : IProductDal
    {
        IEnumerable<Product> FilterTag(string tag);
    }
}
