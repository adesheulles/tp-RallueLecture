using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ppe
{
    class Hash
    {
        public string GetHashPassword(string passWord)
        {
			var message = Encoding.ASCII.GetBytes(passWord);
            SHA256Managed hashString = new SHA256Managed();
            string hex="";
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
