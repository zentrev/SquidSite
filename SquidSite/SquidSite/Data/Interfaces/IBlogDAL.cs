using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Models;

namespace SquidSite.Database.Interfaces
{
    public interface IBlogDAL
    {
        IEnumerable<Blog> GetAll();
        IEnumerable<Blog> GetPinned();
        IEnumerable<Blog> Search(string Title);
        IEnumerable<Blog> Search(int BlogID);
        IEnumerable<Blog> Filter(Blog.eBlogTag tag);

        bool AddBlog(Blog blog, int userId);
        bool DeleteBlog(int BlogId);
        bool DeleteBlog(Blog blog);
        bool EditBlog(int BlogId, Blog blog);
        Blog GetBlog(int BlogId);

        bool AddComment(Comment comment, int blogId, int userId);
        bool DeleteComment(int CommentId);
        bool DeleteComment(Comment comment);
        bool EditComment(int CommentId, Comment comment);
        Comment GetComment(int CommentId);
    }
}
