using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinAppToLearnFrom.Models;

namespace XamarinAppToLearnFrom.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewActivityPage : ContentPage
    {
        public Activity activity { get; set; }

        public NewActivityPage()
        {
            InitializeComponent();

            activity = new Activity
            {
                Name = "Item name",
                Description = "This is an item description.",
                GoalTime = new TimeSpan(2, 0, 0)
            };

            BindingContext = this;
        }

        

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddActivity", activity);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}