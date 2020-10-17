using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P507Pr0ject
{
    public static class Extentions
    {
        public static bool IsEmail(this string email)
        {
			try
			{
				MailAddress mail = new MailAddress(email);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
        }

		public static string HashPassword(this string password)
		{
			byte[] bytePassword = Encoding.ASCII.GetBytes(password);
			SHA256Managed md5 = new SHA256Managed();
			byte[] hashBytePassword = md5.ComputeHash(bytePassword);

			return Encoding.ASCII.GetString(hashBytePassword);
		}
    }
}
