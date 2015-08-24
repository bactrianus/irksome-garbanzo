using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;

namespace Aspose.Cells.Cloud.Examples
{
    class Common
    {
        public static string APP_SID = null;
        public static string APP_KEY = null;
        static Common()
        {
            if (APP_SID == null || APP_KEY == null)
            {
                throw new Exception("Both APP_SID and APP_KEY must not be null");
            }
        }
        public static string STORAGE = null;
        public static string BASE_PATH = "http://api.aspose.com/v1.1/";

        public static string SignRequestUrl(string url) {
            if (!url.Contains('?'))
            {
                url += '?';
            }
            else
            {
                url += '&';
            }

            url += "appSID=" + APP_SID;

            byte[] key = System.Text.Encoding.UTF8.GetBytes(APP_KEY);
            System.Security.Cryptography.HMACSHA1 algorithm = new System.Security.Cryptography.HMACSHA1(key);
            byte[] sequence = System.Text.ASCIIEncoding.ASCII.GetBytes(url);
            byte[] hash = algorithm.ComputeHash(sequence);
            string signature = System.Convert.ToBase64String(hash);
            signature = signature.TrimEnd('=');
            url += "&signature=" + signature;

            return url;
        }

        public static byte[] ExecuteRequest(string url, string method, byte[] requestData = null)
        {
            Console.WriteLine("{0} {1}", method, url);

            WebRequest req = WebRequest.Create(new Uri(url));
            req.Method = method;
            req.ContentType = "application/json";
            req.ContentLength = 0;
            if (requestData != null)
            {
                req.ContentLength = requestData.Length;
                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(requestData, 0, requestData.Length);
                }
            }

            WebResponse res = req.GetResponse();
            using (MemoryStream ms = new MemoryStream())
            {
                res.GetResponseStream().CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static string GetPath(Type t, string filename)
        {
            string c = t.FullName;
            c = c.Replace("Aspose.Cells.Cloud.Examples.", "");
            c = c.Replace('.', Path.DirectorySeparatorChar);
            string p = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", c));
            if (filename != null)
            {
                p = Path.Combine(p, filename);
            }
            Console.WriteLine("Using {0}", p);
            return p;
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
        }
    }
}
