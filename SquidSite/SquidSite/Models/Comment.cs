using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Comment
    {
        public int CommentId;
        public Blog CommentBlog;
        public User CommentUser;
        public DateTime CommentDateEdited;
        public string CommentText;
    }
}
