using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SquidSite.Models;

namespace SquidSite.Data.Interfaces
{
    interface IUserDAL
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Search(string name);
        IEnumerable<User> Search(int ID);
        IEnumerable<User> Filter(User.eUserType userType);

        bool ValidateUser(string userName, string password);
        bool AddUser(User user);
        bool DeleteUser(int Key);
        bool DeleteUser(User blog);
        bool EditUSer(int key, User user);
        BlogPost GetUser(int key);
        int GetKey(User blog);
    }
}
