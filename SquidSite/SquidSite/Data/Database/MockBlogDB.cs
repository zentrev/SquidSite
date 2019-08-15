using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Database.Interfaces;
using SquidSite.Models;

namespace SquidSite.Data.Database
{
    public class MockBlogDB : IBlogDAL
    {
        public static List<BlogPost> mockDB = new List<BlogPost>()
        {
            new BlogPost() { title="Blog1", text="TestBlog1", datePosted=DateTime.Now },
            new BlogPost() { title="Blog3", text="TestBlog3", datePosted=DateTime.Now },
        };

        public bool AddBlog(BlogPost blog)
        {
            mockDB.Add(blog);
            return true;
        }

        public bool DeleteBlog(int Key)
        {
            mockDB.RemoveAt(Key);
            return true;
        }

        public bool DeleteBlog(BlogPost blog)
        {
            mockDB.Remove(blog);
            return true;
        }

        public bool EditBlog(int Key, BlogPost blog)
        {
            mockDB[Key] = blog;
            return true;
        }

        public IEnumerable<BlogPost> Filter(BlogPost.eBlogTag tag)
        {
            return mockDB.Where(b => b.tag.HasFlag(tag));
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return mockDB;
        }

        public BlogPost GetBlog(int Key)
        {
            return mockDB[Key];
        }

        public int GetKey(BlogPost blog)
        {
            for(int i = 0; i < mockDB.Count; i++)
            {
                if(mockDB[i] == blog)
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerable<BlogPost> GetPinned()
        {
            return mockDB.Where(b => b.tag.HasFlag(BlogPost.eBlogTag.PINNED));
        }

        public IEnumerable<BlogPost> Search(string Title)
        {
            return mockDB.Where(b => b.title.Contains(Title));
        }

        public IEnumerable<BlogPost> Search(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
