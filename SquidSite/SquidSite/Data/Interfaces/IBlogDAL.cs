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
        IEnumerable<Blog> Search(int ID);
        IEnumerable<Blog> Filter(Blog.eBlogTag tag);

        bool AddBlog(Blog blog);
        bool DeleteBlog(int Key);
        bool DeleteBlog(Blog blog);
        bool EditBlog(int Key, Blog blog);
        Blog GetBlog(int Key);
        int GetKey(Blog blog);
    }
}
