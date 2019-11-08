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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();

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