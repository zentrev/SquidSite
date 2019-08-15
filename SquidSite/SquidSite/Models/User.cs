using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            DEVBLOG = 1 << 3,
            PINNED = 1 << 4,
        }
    }
}
