using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                enterButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
                //logo.Source = ImageSource.FromResource("TestApp1.iOS.Assets.Logo.png");
            }

            //Button navigation
            enterButton.Clicked += async (sender, args) =>
            {
                //await logo.ScaleTo(10, 1000);
                await Navigation.PushAsync(new MainPage { });
            };
        }

        private async void OnSwiped(object sender, SwipedEventArgs e)
        {

            await Navigation.PushAsync(new MainPage { });
        }
    }
}