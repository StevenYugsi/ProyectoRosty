using System.Security.Cryptography;
using System.Text;

namespace ProyectoRosty.Services
{
    public class Utilitarios
    {
        public static string EncriptarClave(string clave)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesClave = Encoding.UTF8.GetBytes(clave);
                byte[] hashbytes = sha256.ComputeHash(bytesClave);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashbytes)
                {
                    sb.Append(b.ToString("x2")); //Formato Decimal
                }
                return sb.ToString();
            }
        }
    }
}
