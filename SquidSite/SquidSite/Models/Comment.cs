using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Comment
    {
        public int CommentId;
        public int BlogId;
        public int WriterId;
        public DateTime dateEdited;
        public string text;
    }
}
