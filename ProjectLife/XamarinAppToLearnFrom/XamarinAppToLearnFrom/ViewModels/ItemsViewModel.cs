using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinAppToLearnFrom.Models;
using XamarinAppToLearnFrom.Views;

namespace XamarinAppToLearnFrom.ViewModels
{

    public class ActivitiesViewModel : BaseViewModel
    {
        public ObservableCollection<Activity> Activities { get; set; }
        public Command LoadActivityList { get; set; }

        public ActivitiesViewModel()
        {
            Title = "Activities";
            Activities = new ObservableCollection<Activity>();
            LoadActivityList = new Command(async () => await ExecuteLoadActivitiesCommand());

            MessagingCenter.Subscribe<NewActivityPage, Activity>(this, "AddActivity", async (obj, activity) => {
                var newActivity = activity as Activity;
                Activities.Add(newActivity);
                await DataStore.AddItemAsync(newActivity);
            });
        }

        async Task ExecuteLoadActivitiesCommand()
        {
            IsBusy = true;

            try
            {
                Activities.Clear();
                var activities = await DataStore.GetItemsAsync(true);
                foreach (var activity in activities)
                {
                    Activities.Add(activity);
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        async Task ExecuteLoadItemsCommand()
        {

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    //Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}