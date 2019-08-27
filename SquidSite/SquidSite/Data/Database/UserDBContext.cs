using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Data.Interfaces;
using SquidSite.Models;

namespace SquidSite.Data.Database
{
    public class UserDBContext : IUserDAL
    {
        private readonly SquidSiteDbContext _context;
        public UserDBContext(SquidSiteDbContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            bool accepted = false;
            if (user != null)
            {
                accepted = true;
            }

        }

        public bool DeleteUser(int Key)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User blog)
        {
            throw new NotImplementedException();
        }

        public bool EditUser(int key, User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Filter(User.eUserType userType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetKey(User blog)
        {
            throw new NotImplementedException();
        }

        public Blog GetUser(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Search(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Search(int ID)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
