using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public abstract class Product
    {
        int key = -1;
        string title = "Default Item Title";
        float cost = 0.00f;
        string description = "Default Item Description";
        List<string> imageURLS;
    }
}
