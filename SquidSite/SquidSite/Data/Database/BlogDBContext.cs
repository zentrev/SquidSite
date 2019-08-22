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
            return _context.Blogs.Include("BlogComments.Comment").Include("UserBlog.User").Where(b => b.BlogTag == Blog.eBlogTag.PINNED);
        }
        public IEnumerable<Blog> Search(string Title)
        {
            return _context.Blogs.Include("BlogComments.Comment").Include("UserBlog.User").Where(b => b.BlogTitle.Contains(Title));
        }
        public IEnumerable<Blog> Search(int BlogID)
        {
            return _context.Blogs.Include("BlogComments.Comment").Include("UserBlog.User").Where(b => b.BlogId == BlogID);
        }
        public IEnumerable<Blog> Filter(Blog.eBlogTag tag)
        {
            return _context.Blogs.Include("BlogComments.Comment").Include("UserBlog.User").Where(b => b.BlogTag == tag);
        }
        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs.Include("BlogComments.Comment").Include("UserBlog.User");
        }

        public bool AddBlog(Blog blog, int userId)
        {
            if (_context.Users.Find(userId) != null)
            {
                UserBlog ub = new UserBlog
                {
                    Blog = blog,
                    User = _context.Users.First(u => u.ID == userId),
                    UserId = userId,
                };

                _context.Add(ub);
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
            return _context.Blogs.Include("BlogComments.Comment").Include("UserBlog.User").First(b => b.BlogId == BlogId);
        }
        #endregion


        #region Comment Functions
        public bool AddComment(Comment comment, int blogId, int userId)
        {
            if (_context.Users.Find(userId) != null && _context.Blogs.Find(blogId) != null)
            {
                UserComment uc = new UserComment
                {
                    Comment = comment,
                    User = _context.Users.First(u => u.ID == userId),
                    UserId = userId,
                };

                BlogComment bc = new BlogComment
                {
                    Comment = comment,
                    Blog = _context.Blogs.First(b => b.BlogId == blogId),
                    BlogId = blogId,
                };

                _context.Add(uc);
                _context.Add(bc);
                _context.SaveChanges();
                return true;
            } else
            {
                return false;
            }
        }
        public Comment GetComment(int CommentId)
        {
            return _context.Comments.Include("BlogComments.Blog").Include("UserComment.User").First(c => c.CommentId == CommentId);
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
