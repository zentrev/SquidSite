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
        bool DeleteBlog(int index);
        bool DeleteBlog(BlogPost blog);
        bool EditBlog(int index, BlogPost blog);
        BlogPost GetBlog(int index);
        int GetIndex(BlogPost blog);
    }
}
