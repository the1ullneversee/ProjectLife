using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using XamarinAppToLearnFrom.Models;
using XamarinAppToLearnFrom.Services;

namespace XamarinAppToLearnFrom.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //uses Dependency service to fetch the type specified. 
        //public IDataStoreActivity<Activity> ActivityDataStore => DependencyService.Get<IDataStoreActivity<Activity>>();
        public IDataStore<Activity> DataStore => DependencyService.Get<IDataStore<Activity>>();

        
        
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
