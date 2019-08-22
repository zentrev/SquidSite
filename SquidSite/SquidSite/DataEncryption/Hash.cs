using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace SquidSite.DataEncryption
{
    public static class Hash
    {
        private const int WF = 18;

        private static string GetRandomBSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(WF);
        }

        public static string BHashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomBSalt());
        }

        public static bool BValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}
