using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestApp1.ViewModels;

namespace TestApp1
{
    public partial class App : Application
    {

        static ResultsViewModel resultsViewModel;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Page1());
            resultsViewModel = new ResultsViewModel();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }


        public static ResultsViewModel ResultsViewModel
        {
            get
            {
                if(resultsViewModel == null)
                {
                    resultsViewModel = new ResultsViewModel();
                }
                return resultsViewModel;
            }
        }

    }
}
