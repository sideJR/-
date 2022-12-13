using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Text;
using System.Security.Cryptography;

namespace CM5_雲端_3_DES_加密.Controllers
{
    public class SecurityController : Controller
    {
        public string Encode(string OldText, string Key)
        {
            TripleDES des = CreateDES(Key);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] X = Encoding.Unicode.GetBytes(OldText);  //把原文轉換為2進位
            byte[] Y = ct.TransformFinalBlock(X, 0, X.Length);  //利用2進位的原文與真key，產生2進位的密文
            
            return Convert.ToBase64String(Y);
        }
        public string Decode(string NewText, string Key)
        {
            byte[] b = Convert.FromBase64String(NewText);
            TripleDES des = CreateDES(Key);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);

            return Encoding.Unicode.GetString(output);
        }
        public static TripleDES CreateDES(string key)

        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }
        // GET: Security
        public ActionResult Index()
        {
            return View();
        }
    }
}