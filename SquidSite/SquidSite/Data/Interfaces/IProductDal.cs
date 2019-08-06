using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Data.Interfaces
{
    interface IProductDal
    {
        IEnumerable<BlogPost> GetAll();
        IEnumerable<BlogPost> Search(string Name);

    }
}
