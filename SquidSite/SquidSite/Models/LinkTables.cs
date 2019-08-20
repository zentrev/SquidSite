﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquidSite.Models
{
    public class BlogComment
    {
        public int BlogId;
        public Blog Blog;
        public int CommentId;
        public Comment Comment;
    }
    public class UserBlog
    {
        public int UserId;
        public User User;
        public int BlogId;
        public Blog Blog;
    }
    public class UserComment
    {
        public int UserId;
        public User User;
        public int CommentId;
        public Comment Comment;
    }
    public class UserGame
    {
        public int UserID;
        public User User;
        public int GameID;
        public Game Game;
    }
    public class ProductImages
    {
        public int ProdcutID;
        public Product Product;
        public int ProductImageID;
        public ProdutImage ProductImage;
    }
}
