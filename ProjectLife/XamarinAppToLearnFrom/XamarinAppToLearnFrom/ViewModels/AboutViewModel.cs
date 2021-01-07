using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamarinAppToLearnFrom.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Models.Profile UserProfile;

        public AboutViewModel()
        {
            UserProfile = new Models.Profile();
            UserProfile.FirstName = "Thomas1";
            Title = "About";
            _name = "John II";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        private string _name;
        public string Name
        {
            get { return _name; }
        }

        public ICommand OpenWebCommand { get; }
    }
}