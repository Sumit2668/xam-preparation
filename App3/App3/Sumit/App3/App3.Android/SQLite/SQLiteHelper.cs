using App3.Droid.SQLite;
using App3.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteHelper))]
namespace App3.Droid.SQLite
{
        public class SQLiteHelper : ISQLiteHelper
        {
            public string GetLocalFilePath(string filename)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return Path.Combine(path, filename);
            }
        }
}