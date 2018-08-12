

using App3.iOS.SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteHelper))]
namespace App3.iOS.SQLite
{
   public class SQLiteHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}