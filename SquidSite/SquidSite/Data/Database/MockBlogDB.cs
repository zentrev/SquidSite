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
            new BlogPost() { title="Blog1", content="TestBlog1", posterUserName="Test", datePosted=DateTime.Now },
            new BlogPost() { title="Blog2", content="TestBlog2", posterUserName="Test", datePosted=DateTime.Now },
            new BlogPost() { title="Blog3", content="TestBlog3", posterUserName="Test", datePosted=DateTime.Now },
        };

        public bool AddBlog(BlogPost blog)
        {
            mockDB.Add(blog);
            return true;
        }

        public bool DeleteBlog(int index)
        {
            mockDB.RemoveAt(index);
            return true;
        }

        public bool DeleteBlog(BlogPost blog)
        {
            mockDB.Remove(blog);
            return true;
        }

        public bool EditBlog(int index, BlogPost blog)
        {
            mockDB[index] = blog;
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

        public BlogPost GetBlog(int index)
        {
            return mockDB[index];
        }

        public int GetIndex(BlogPost blog)
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
    }
}
