using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Product
    {
        public enum eProductType
        {
            NONE = 1 << 0,
            GAME = 1 << 1,
            MERCH = 1 << 2,
        }

        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string Title { get; set; }
        public float Cost { get; set; }
        public string Description { get; set; }
        public List<ProdutImage> ImageURLS { get; set; }

        #region Game
        public string DownloadLink { get; set; }
        public string DemoLink { get; set; }
        public string DemoDownloadLink { get; set; }
        #endregion

        #region Merch
        public enum eMerchTags
        {
            NONE = 1 << 0,
            SHIRT = 1 << 1,
            HAT = 1 << 2,
            SOCKS = 1 << 3,
            MISC = 1 << 4
        }

        public enum eMerchSize
        {
            NONE = 1 << 0,
            SMALL = 1 << 1,
            MEDUIM = 1 << 2,
            LARGE = 1 << 3,
        }

        public eMerchTags MerchTags { get; set; } = 0;
        public eMerchSize MerchSize { get; set; } = 0;
        #endregion
    }
}
