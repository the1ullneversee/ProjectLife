using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinAppToLearnFrom.Services
{
    public interface IDataStore<T>
    {
        //each function returns a Task to make the process async.
        //Task<bool> RegisterActivity(T activty);
        //Task<bool> EditActivity(T activity);
        //Task<bool> DeleteActivity(T activity);
        //Task<bool> GetItemAsync(string id);
        //Task<IEnumerable<T>> GetActivitiesAsync(bool forceRefresh = false);

        Task<bool> AddItemAsync(T activty);
        Task<bool> UpdateItemAsync(T activty);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }

    //<T> where T is a general type.
    public interface IDataStoreActivity<T>
    {
        //each function returns a Task to make the process async.
        Task<bool> RegisterActivity(T activty);
        Task<bool> EditActivity(T activity);
        Task<bool> DeleteActivity(T activity);
        Task<bool> GetItemAsync(string id);
        Task<IEnumerable<T>> GetActivitiesAsync(bool forceRefresh = false);

    }

    public interface IProfileDataStore<T>
    {
        Task<bool> GetProfile(T profile);
    }
}
