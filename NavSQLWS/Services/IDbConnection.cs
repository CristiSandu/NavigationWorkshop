using NavSQLWS.Models;

namespace NavSQLWS.Services
{
    public interface IDbConnection
    {
        Task<int> DeleteAllItemsAsync();
        Task<int> DeleteItemAsync(MonkeyModel item);
        Task<MonkeyModel> GetItemAsync(int id);
        Task<List<MonkeyModel>> GetItemsAsync();
        Task<int> SaveAllItemAsync(List<MonkeyModel> items);
        Task<int> SaveItemAsync(MonkeyModel item);
        Task<int> UpdateItemAsync(MonkeyModel item);
    }
}