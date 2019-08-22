using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Game : Product
    {
        public string DownloadLink { get; set; }
        public string DemoLink { get; set; }
        public string DemoDownloadLink { get; set; }
    }
}
