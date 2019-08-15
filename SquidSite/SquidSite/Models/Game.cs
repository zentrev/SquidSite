using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Game : Product
    {
        public string DownloadLink { get; set; } // Or something to allow the user to download or play the game.
    }
}
