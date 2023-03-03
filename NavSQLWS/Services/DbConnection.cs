using NavSQLWS.Models;
using SQLite;

namespace NavSQLWS.Services;

public class DbConnection
{
    SQLiteAsyncConnection Database;

    public const SQLite.SQLiteOpenFlags Flags =
      // open the database in read/write mode
      SQLite.SQLiteOpenFlags.ReadWrite |
      // create the database if it doesn't exist
      SQLite.SQLiteOpenFlags.Create |
      // enable multi-threaded database access
      SQLite.SQLiteOpenFlags.SharedCache;

    public DbConnection()
    {
    }

    async Task Init()
    {
        if (Database is not null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MonkeyDb.db");

        try
        {
            Database = new SQLiteAsyncConnection(databasePath, Flags);
        }
        catch (Exception ex)
        {

        }

        await Database.CreateTableAsync<MonkeyModel>();
    }

    public async Task<List<MonkeyModel>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<MonkeyModel>().ToListAsync();
    }

    public async Task<MonkeyModel> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<MonkeyModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(MonkeyModel item)
    {
        await Init();
        return await Database.InsertAsync(item);
    }

    public async Task<int> UpdateItemAsync(MonkeyModel item)
    {
        await Init();
        return await Database.UpdateAsync(item);
    }

    public async Task<int> SaveAllItemAsync(List<MonkeyModel> items)
    {
        await Init();
        return await Database.InsertAllAsync(items);
    }

    public async Task<int> DeleteItemAsync(MonkeyModel item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<int> DeleteAllItemsAsync()
    {
        await Init();
        return await Database.DeleteAllAsync<MonkeyModel>();
    }
}
