using NotasRapidas.Model.Entities;
using NotasRapidas.Storage.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace NotasRapidas.Storage
{
    public class DatabaseManager
    {
        private static SQLiteConnection _database;

        public DatabaseManager()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTable<Nota>();
        }

        public List<Nota> GetItems()
        {
            return _database.Table<Nota>().ToList();
        }

        public Nota GetItem(string id)
        {
            return _database.Table<Nota>().FirstOrDefault(i => i.Id == id);
        }

        public void SaveItem(Nota item)
        {
            var all = _database.Table<Nota>().AsEnumerable().Where(t => t.Id == item.Id).ToList();
            if (all.Count == 0)
                _database.Insert(item);
            else
                _database.Update(item);
        }

        public void DeleteItem(Nota item)
        {
            _database.Delete(item);
        }
    }
}
