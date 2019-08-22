using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public Blog CommentBlog { get; set; }
        public User CommentUser { get; set; }
        public DateTime CommentDateEdited { get; set; }
        public string CommentText { get; set; }
    }
}
