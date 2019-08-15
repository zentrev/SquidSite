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
        public User User;
        public string Title;
        public DateTime DatePosted;
        public DateTime DateEdited;
        public string Text;
        public eBlogTag Tag;
        public List<Comment> comments;
    }
}
