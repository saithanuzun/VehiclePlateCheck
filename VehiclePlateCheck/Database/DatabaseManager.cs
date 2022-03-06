using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePlateCheck.Database
{
    public class DatabaseManager
    {
        private readonly SQLiteAsyncConnection _database;
        
        public DatabaseManager(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DatabaseModel>();
        }
        public Task<List<DatabaseModel>> GetDatabaseAsync()
        {
            return _database.Table<DatabaseModel>().ToListAsync();
        }
        public Task<int> SaveDatabaseAsync(DatabaseModel model)
        {
            return _database.InsertAsync(model);
        }


    }
}
