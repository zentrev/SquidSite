using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace SquidSite.DataEncryption
{
    public static class _BCrypt
    {
        private const int WF = 18;

        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(WF);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
