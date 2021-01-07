using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using XamarinAppToLearnFrom.Models;

namespace XamarinAppToLearnFrom.Services
{

    public class ProfileMockDataStore : IProfileDataStore<Profile>
    {
        public Task<bool> GetProfile(Profile profile)
        {
            throw new NotImplementedException();
        }
    }

    public class MockActivityDataStore : IDataStoreActivity<Activity>
    {
        readonly List<Activity> activitiesList;

        public MockActivityDataStore()
        {
            activitiesList = new List<Activity>
            {
                new Activity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Reading",
                    Description = "Goal to read more material, whether books, newspapers, or online articles",
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                    GoalTime = new TimeSpan(2, 0, 0),
                    Active = true,

                }
            };
        }

        public async Task<bool> RegisterActivity(Activity activty)
        {
            if(activitiesList != null)
            {
                activitiesList.Add(activty);
            }

            //Creates a Task<TResult> that's completed successfully with the specified result.
            return await Task.FromResult(true);
        }

        public Task<bool> EditActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Activity>> GetActivitiesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(activitiesList);
        }

        public Task<bool> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteActivity(Activity activity)
        {
            throw new NotImplementedException();
        }
    }

    public class MockDataStore : IDataStore<Activity>
    {
        readonly List<Activity> activitiesList;
        //readonly List<Item> items;

        public MockDataStore()
        {
            //items = new List<Item>()
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            //};
            activitiesList = new List<Activity>
            {
                new Activity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Reading",
                    Description = "Goal to read more material, whether books, newspapers, or online articles",
                    StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                    GoalTime = new TimeSpan(2, 0, 0),
                    Active = true,

                }
            };
        }

        public async Task<bool> AddItemAsync(Activity activity)
        {
            activitiesList.Add(activity);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Activity activity)
        {
            var oldActivity = activitiesList.Where((Activity arg) => arg.Id == activity.Id).FirstOrDefault();
            activitiesList.Remove(oldActivity);
            activitiesList.Add(activity);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            //var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            //items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Activity> GetItemAsync(string id)
        {
            return await Task.FromResult(activitiesList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Activity>> GetItemsAsync(bool forceRefresh = false)
        {
            GetItemsFromDatabase();
            return await Task.FromResult(activitiesList);
        }

        private string connectionStr = @"Server=DESKTOP-UUOQ7VJ\SQLEXPRESS;Database=Life;User Id=FormUser;Password=password123;";
        private void GetItemsFromDatabase()
        {
            string queryString =
            "SELECT * FROM dbo.Activities;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                //call read before accessing data.
                while(reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }
            }
        }

        private static void ReadSingleRow(IDataRecord record)
        {
            Debug.WriteLine($"{record[0]}{record[1]}{record[2]}{record[3]}");
        }
            
    }
}