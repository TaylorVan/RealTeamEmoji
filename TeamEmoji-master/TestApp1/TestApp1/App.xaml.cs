using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestApp1.ViewModels;
using System.IO;

namespace TestApp1
{
    public partial class App : Application
    {

        static ResultsViewModel resultsViewModel;

        //Database instance stored in this file, App.xaml.cs
        static PieceDB database;

        public static PieceDB PieceDatabase
        {
            get
            {
                //If the database hasn't been opened yet
                if (database == null)
                {
                    //Filename 
                    var sqliteFilename = "lego_parts.db3";
                    //Directory
                    string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    //Filepath
                    var path = Path.Combine(documentsDirectoryPath, sqliteFilename);
                    //Open database at path specified
                    database = new PieceDB(path);
                }
                return database;
            }
        }

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
