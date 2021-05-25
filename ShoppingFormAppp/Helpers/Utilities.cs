using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFormAppp.Helpers
{
    static class Utilities
    {
        public static bool IsEmpty (string[] arr1)
        {
            foreach (var a in arr1)
            {
                if (string.IsNullOrWhiteSpace(a))
                {
                    return false;
                }
            }
            return true;
        }
        public static string HasMe(this string pass)
        {
            byte[] byteArr = Encoding.UTF8.GetBytes(pass);
            var hasPass = SHA256Managed.Create().ComputeHash(byteArr);

            string pasString = Encoding.UTF8.GetString(hasPass);
            return pasString;
        }
    }

}
