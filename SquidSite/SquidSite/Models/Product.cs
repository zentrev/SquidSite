using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Product
    {
        public int key { get; set; }
        public string title { get; set; }
        public float cost { get; set; }
        public string description { get; set; }
        public List<string> imageURLS { get; set; }
    }
}
