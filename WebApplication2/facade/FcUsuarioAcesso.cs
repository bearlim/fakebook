using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication2.facade
{
    public static class FcUsuarioAcesso
    {
        public static string md5Encrypt(string senha)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();

            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(senha));

            byte[] hashResult = mD5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < hashResult.Length; i++)
            {
                stringBuilder.Append(hashResult[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}