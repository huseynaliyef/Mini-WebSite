using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Functionaol_Methoods
{
    public class Improtant_Functions
    {
        public string HashPassword(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                string newHash = sb.ToString();
                return newHash;
            }

        }
    }
}
