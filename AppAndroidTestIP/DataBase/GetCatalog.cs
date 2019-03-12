using System.Collections.Generic;
using SQLite;

namespace AppAndroidTestIP.DataBase
{
    class GetCatalog<T> where T : new()
    {
        private SQLiteConnection db_conn;

        public GetCatalog()
        {
            db_conn = ConnectionDB.SQLiteConnection();
            db_conn.CreateTable<T>();
        }

        public List<T> GetItems()
        {
            return db_conn.Table<T>().ToList();
        }

        public T GetItem(int id)
        {
            return db_conn.Get<T>(id);
        }

        public void InsertItem(T item)
        {
            db_conn.Insert(item);
        }
    }
}