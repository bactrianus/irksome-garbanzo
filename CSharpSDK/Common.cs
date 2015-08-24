using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static string BASE_PATH = null;

        public static Aspose.Cloud.StorageService GetStorageSdk()
        {
            return new Aspose.Cloud.StorageService(APP_SID, APP_KEY);
        }

        public static Aspose.Cloud.CellsService GetCellsSdk()
        {
            return new Aspose.Cloud.CellsService(APP_SID, APP_KEY);
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
