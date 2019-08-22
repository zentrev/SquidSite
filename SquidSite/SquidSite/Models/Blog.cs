using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Blog
    {
        [Flags]
        public enum eBlogTag
        {
            NONE        = 1 << 0,
            UPDATE      = 1 << 1,
            ANOUNCEMENT = 1 << 2,
            DEVBLOG     = 1 << 3,
            PINNED      = 1 << 4,
        }
        public int BlogId;
        public User BlogUser;
        public string BlogTitle;
        public DateTime BlogDatePosted;
        public DateTime BlogDateEdited;
        public string BlogContent;
        public eBlogTag BlogTag;
        public List<BlogComment> BlogComments;
    }
}
