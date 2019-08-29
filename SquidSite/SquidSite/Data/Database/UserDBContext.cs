using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Data.Interfaces;
using SquidSite.Models;
using SquidSite.DataEncryption;

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
            if(_context.Users.FirstOrDefault(u => u.userName.Equals(user.userName, StringComparison.OrdinalIgnoreCase)) == null)
            {
                _context.Users.Add(user);
                return true;
            }
            return false;
        }

        public bool DeleteUser(int Key)
        {
            if(_context.Users.First(u => u.ID == Key) != null)
            {
                _context.Users.Remove(_context.Users.First(u => u.ID == Key));
                return true;
            }
            return false;
        }


        public bool EditUser(int key, User user)
        {
            if(Search(key) != null)
            {
                User currentUser = Search(key);
                _context.Update(currentUser);
                currentUser = user;
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public IEnumerable<User> Filter(User.eUserType userType)
        {
            return _context.Users.Where(u => u.userType == userType);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        //public bool DeleteUser(User blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public int GetKey(User blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public Blog GetUser(int key)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<User> Search(string name)
        {
            return _context.Users.Where(u => u.userName.Contains(name));
        }

        public User Search(int ID)
        {
            return _context.Users.First(u => u.ID == ID);
        }

        public bool ValidateUser(string userName, string password)
        {
            User existing = _context.Users.First(u => u.userName == userName);
            if (existing != null)
            {
                if(Hash.BValidatePassword(password, existing.passwordHash))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
