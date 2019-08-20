using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Merchandise : Product
    {
        public enum eMerchTags
        {
            NONE = 1 << 0,
            SHIRT = 1 << 2,
            HAT = 1 << 3,
            SOCKS = 1 << 4,
            MISC = 1 << 5
        }

        public enum eMerchSize
        {
            NONE = 1 << 0,
            SMALL = 1 << 1,
            MEDUIM = 1 << 2,
            LARGE = 1 << 3,
        }

        public eMerchTags MerchTags {get;set;} = 0;
        public eMerchSize MerchSize {get;set;} = 0;

    }
}
