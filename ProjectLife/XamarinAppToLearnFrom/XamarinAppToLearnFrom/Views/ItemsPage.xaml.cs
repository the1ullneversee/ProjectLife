using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinAppToLearnFrom.Models;
using XamarinAppToLearnFrom.Views;
using XamarinAppToLearnFrom.ViewModels;

namespace XamarinAppToLearnFrom.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {

        ActivitiesViewModel viewModel;
        ActivitiesViewModel acViewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ActivitiesViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            //var layout = (BindableObject)sender;
            //var item = (Item)layout.BindingContext;
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewActivityPage()));
            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Activities.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}