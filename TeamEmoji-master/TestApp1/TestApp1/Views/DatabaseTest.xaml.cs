using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabaseTest : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.PieceDatabase.GetAllPieces();

        }

        public DatabaseTest()
        {
            InitializeComponent();
            
        }
    }
}