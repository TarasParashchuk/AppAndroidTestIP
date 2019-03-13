using System;
using System.IO;

namespace AppAndroidTestIP.DataBase
{
    class ConnectionDB
    {
        public static SQLite.SQLiteConnection SQLiteConnection()
        {
            var path = GetDatabasePath();
            var database = new SQLite.SQLiteConnection(path);
            return database;
        }

        private static string GetDatabasePath(string sqliteFilename = "CatalogDataBase.db")
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}