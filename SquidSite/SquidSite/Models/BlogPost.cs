using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    //This is temp until we have a database
    public class BlogPost
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

        public string title;
        public string posterUserName;
        public string posterUserIcon;
        public DateTime datePosted;
        public DateTime dateEdited;
        public string content;
        public eBlogTag tag;
        public List<Comment> comments;

        public struct Comment
        {
            public string posterUserName;
            public string posterUserIcon;
            public DateTime dateEdited;
            public string content;
            public Comment(string _posterUserName, string _posterUserIcon, DateTime _dateEdited, string _content)
            {
                posterUserName = _posterUserName;
                posterUserIcon = _posterUserIcon;
                dateEdited = _dateEdited;
                content = _content;
            }
        }
    }
}
