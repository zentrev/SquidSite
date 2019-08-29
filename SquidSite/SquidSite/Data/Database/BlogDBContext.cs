using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SquidSite.Database.Interfaces;
using SquidSite.Models;

namespace SquidSite.Data.Database
{
    public class BlogDBContext : IBlogDAL
    {

        private readonly SquidSiteDbContext _context;

        public BlogDBContext(SquidSiteDbContext context)
        {
            _context = context;
        }

        #region blogFunctions
        public IEnumerable<Blog> GetPinned()
        {
            return _context.Blogs.Include(b=>b.BlogComments).Include(b => b.BlogUser).Where(b => b.BlogTag == Blog.eBlogTag.PINNED);
        }
        public IEnumerable<Blog> Search(string Title)
        {
            return _context.Blogs.Include(b => b.BlogComments).Include(b => b.BlogUser).Where(b => b.BlogTitle.Contains(Title));
        }
        public IEnumerable<Blog> Search(int BlogID)
        {
            return _context.Blogs.Include(b => b.BlogComments).Include(b => b.BlogUser).Where(b => b.BlogId == BlogID);
        }
        public IEnumerable<Blog> Filter(Blog.eBlogTag tag)
        {
            return _context.Blogs.Include(b => b.BlogComments).Include(b => b.BlogUser).Where(b => b.BlogTag == tag);
        }
        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs.Include(b => b.BlogComments).Include(b => b.BlogUser);
        }

        public bool AddBlog(Blog blog, int userId)
        {
            if (_context.Users.Find(userId) != null)
            {
                blog.BlogUser = _context.Users.Find(userId);

                _context.Add(blog);
                _context.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }
        public bool DeleteBlog(int BlogId)
        {
            if (_context.Blogs.Find(BlogId) != null)
            {
                _context.Blogs.Remove(_context.Blogs.First(b => b.BlogId == BlogId));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteBlog(Blog blog)
        {
            if (_context.Blogs.Find(blog.BlogId) != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditBlog(int BlogId, Blog blog)
        {
            if (_context.Blogs.Find(blog.BlogId) != null)
            {
                Blog btemp = _context.Blogs.First(b =>b.BlogId == BlogId);
                _context.Update(btemp);
                btemp = blog;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Blog GetBlog(int BlogId)
        {
            return _context.Blogs.Include(b => b.BlogComments).Include(b => b.BlogUser).First(b => b.BlogId == BlogId);
        }
        #endregion


        #region Comment Functions
        public bool AddComment(Comment comment, int blogId, int userId)
        {
            if (_context.Users.First(u=> u.ID == userId) != null && _context.Blogs.First(b=>b.BlogId == blogId) != null)
            {

                comment.CommentUser = _context.Users.First(u => u.ID == userId);
                comment.CommentBlog = _context.Blogs.First(b => b.BlogId == blogId);

                 _context.Add(comment);
                _context.Users.First(u => u.ID == userId).UserComments.Add(comment);
                _context.Blogs.First(b => b.BlogId == blogId).BlogComments.Add(comment);

                _context.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }
        public Comment GetComment(int CommentId)
        {
            return _context.Comments.Include(c =>c.CommentBlog).Include(c => c.CommentUser).First(c => c.CommentId == CommentId);
        }
        public bool DeleteComment(int CommentId)
        {
            if (_context.Comments.Find(CommentId) != null)
            {
                _context.Comments.Remove(_context.Comments.First(c => c.CommentId == CommentId));
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteComment(Comment comment)
        {
            if (_context.Comments.Find(comment.CommentId) != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditComment(int CommentId, Comment comment)
        {
            if (_context.Comments.Find(CommentId) != null)
            {
                Comment ctemp = _context.Comments.First(c => c.CommentId == CommentId);
                _context.Update(ctemp);
                ctemp = comment;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
