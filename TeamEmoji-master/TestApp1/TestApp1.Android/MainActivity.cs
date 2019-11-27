using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Plugin.Media;
using Xam.Plugins.OnDeviceCustomVision;
using Android.Content.Res;

namespace TestApp1.Droid
{
    [Activity(Label = "EV3 Identifier", Icon = "@drawable/Logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            await CrossMedia.Current.Initialize(); 

            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AndroidImageClassifier.Init("model.pb", "labels.txt");
            AssetManager assets = Assets;

            //Creates database file if it doesn't exist in app storage
            CreateConnection.Open();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if (App.ResultsViewModel.OverrideBackButton)
            {
                //return;
            }
            base.OnBackPressed();

        }


        protected override void OnRestart()
        {
            //App.ResultsViewModel.IsLoading = false;
            base.OnRestart();
        }

        protected override void OnResume()
        {
            //App.ResultsViewModel.IsLoading = false;
            base.OnResume();
        }

    }
}