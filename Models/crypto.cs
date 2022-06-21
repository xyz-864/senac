using System;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Models
{
    public class Crypto
    {
        public static string Generate(string strInput)
{
    MD5 md5 = new MD5CryptoServiceProvider();

        //provide the string in byte format to the ComputeHash method.
    //This method returns the MD5 hash code in byte array
    byte[] arrHash = md5.ComputeHash(Encoding.UTF8.GetBytes(strInput));


        // use a Stringbuilder to append the bytes from the array to create a hash code string.
    StringBuilder sbHash = new StringBuilder();

        // Loop through byte array of the hashed code and format each byte as a hexadecimal code.
    for (int i = 0; i < arrHash.Length; i++)
    {
    sbHash.Append(arrHash[i].ToString("x2"));
    }

        // Return the hexadecimal MD5 hash code string.
    return sbHash.ToString();
}
    }
}