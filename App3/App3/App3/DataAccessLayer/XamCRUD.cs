using App3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace App3.DataAccessLayer
{
    public class XamCRUD
    {
        readonly SQLiteAsyncConnection database;

        public XamCRUD(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Employee>().Wait();
        }

        public Task<List<Employee>> GetItemsAsync()
        {
            return database.Table<Employee>().ToListAsync();
        }

        public Task<List<Employee>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Employee>("SELECT * FROM [Employee] WHERE [Id] = 0");
        }

        public Task<Employee> GetItemAsync(int id)
        {
            return database.Table<Employee>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateIcon(Employee item)
        {
            return database.UpdateAsync(item);
        }

        public Task<int> SaveItemAsync(Employee item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        

        public Task<int> DeleteItemAsync(Employee item)
        {
            return database.DeleteAsync(item.Id);
        }
    }
}
