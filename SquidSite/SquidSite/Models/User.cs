using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Models;

namespace SquidSite.Models
{
    public class User
    {
        [Flags]
        public enum eUserType
        {
            NONE = 1 << 0,
            STANDARD = 1 << 1,
            ADMIN = 1 << 2,
        }

        public int ID = 0;
        public eUserType userType = 0;
        public string email;
        public string userName;
        public string password;
        public List<Game> ownedGames = new List<Game>();
    }
}
