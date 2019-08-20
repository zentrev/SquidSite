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
        public static List<Blog> mockDB = new List<Blog>()
        {
            /*
            new Blog() {
                BlogId = 1000,
                Title ="Blog1",
                Text ="TestBlog1",
                User = new User(),
                DatePosted =DateTime.Now,
                comments = new List<Comment>(){
                    new Comment(){
                        CommentId = 100,
                        Text = "Hi There",
                        User = new User(),
                        DateEdited = DateTime.Now,
                    }
                }
            },
            new Blog() {
                BlogId = 2000,
                Title ="Blog2",
                Text ="TestBlog2",
                User = new User(),
                DatePosted =DateTime.Now,
                comments = new List<Comment>(){
                    new Comment(){
                        CommentId = 110,
                        User = new User(),
                        Text = "Hi There Im comment",
                        DateEdited =DateTime.Now,

                    }
                }
            },
            new Blog() {
                BlogId = 3003,
                Title ="Blog3",
                Text ="TestBlog3",
                User = new User(),
                DatePosted =DateTime.Now,
                comments = new List<Comment>(){
                    new Comment(){
                        CommentId = 111,
                        User = new User(),
                        Text = "Hi There Im another Comment",
                        DateEdited =DateTime.Now,
                    }
                }
            },*/
        };

        public bool AddBlog(Blog blog)
        {
            mockDB.Add(blog);
            return true;
        }

        public bool DeleteBlog(int Key)
        {
            mockDB.RemoveAt(Key);
            return true;
        }

        public bool DeleteBlog(Blog blog)
        {
            mockDB.Remove(blog);
            return true;
        }

        public bool EditBlog(int Key, Blog blog)
        {
            mockDB[Key] = blog;
            return true;
        }

        public IEnumerable<Blog> Filter(Blog.eBlogTag tag)
        {
            return mockDB.Where(b => b.Tag.HasFlag(tag));
        }

        public IEnumerable<Blog> GetAll()
        {
            return mockDB;
        }

        public Blog GetBlog(int ID)
        {
            return mockDB.First(b => b.BlogId == ID);
        }

        public int GetKey(Blog blog)
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

        public IEnumerable<Blog> GetPinned()
        {
            return mockDB.Where(b => b.Tag.HasFlag(Blog.eBlogTag.PINNED));
        }

        public IEnumerable<Blog> Search(string Title)
        {
            return mockDB.Where(b => b.Title.Contains(Title));
        }

        public IEnumerable<Blog> Search(int ID)
        {
            return mockDB.Where(b => b.BlogId == ID);
        }
    }
}
