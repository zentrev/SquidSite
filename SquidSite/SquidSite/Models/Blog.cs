using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public User BlogUser { get; set; }
        public string BlogTitle { get; set; }
        public DateTime BlogDatePosted { get; set; }
        public DateTime BlogDateEdited { get; set; }
        public string BlogContent { get; set; }
        public eBlogTag BlogTag { get; set; }
        public ICollection<Comment> BlogComments { get; set; }
        [Flags]
        public enum eBlogTag
        {
            NONE = 1 << 0,
            UPDATE = 1 << 1,
            ANOUNCEMENT = 1 << 2,
            DEVBLOG = 1 << 3,
            PINNED = 1 << 4,
        }
    }
}
