using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Models;

namespace SquidSite.Database.Interfaces
{


    public interface IBlogDAL
    {
        IEnumerable<BlogPost> GetAll();
        IEnumerable<BlogPost> GetPinned();
        IEnumerable<BlogPost> Search(string Title);
        IEnumerable<BlogPost> Filter(BlogPost.eBlogTag tag);

        bool AddBlog(BlogPost blog);
        bool DeleteBlog(int Key);
        bool DeleteBlog(BlogPost blog);
        bool EditBlog(int Key, BlogPost blog);
        BlogPost GetBlog(int Key);
        int GetKey(BlogPost blog);
    }
}
