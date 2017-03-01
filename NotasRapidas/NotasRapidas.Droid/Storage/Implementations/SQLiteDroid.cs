using NotasRapidas.Droid.Storage.Implementations;
using NotasRapidas.Storage.Interfaces;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace NotasRapidas.Droid.Storage.Implementations
{
    public class SQLiteDroid:ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath + sqliteFilename);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}