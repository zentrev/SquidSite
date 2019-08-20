using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Comment
    {
        public int CommentId;
        public Blog Blog;
        public User User;
        public DateTime DateEdited;
        public string Text;
    }
}
