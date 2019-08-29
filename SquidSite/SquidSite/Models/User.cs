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

        public int ID { get; set; } = 0;
        public eUserType userType { get; set; } = 0;
        public string email { get; set; }
        public string userName { get; set; }
        public string passwordHash { get; set; }
        public List<UserProduct> ownedGames { get; set; } = new List<UserProduct>();
        public List<Blog> UserBlogs { get; set; }
        public List<Comment> UserComments { get; set; }
    }
}
