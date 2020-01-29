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
    public partial class TopThree : ContentPage
    {
        public TopThree()
        {
            InitializeComponent();

            //imageToIdentify.Source = "_" + App.ResultsViewModel.PieceGuessed.PartNum + ".jpg";
            //imageToIdentify.IsVisible = true;

            imageOne.Source = "_" + App.ResultsViewModel.PiecesGuessed.ElementAt(0).PartNum + ".jpg";
            imageTwo.Source = "_" + App.ResultsViewModel.PiecesGuessed.ElementAt(1).PartNum + ".jpg";
            imageThree.Source = "_" + App.ResultsViewModel.PiecesGuessed.ElementAt(2).PartNum + ".jpg";

            imageOne.IsVisible = true;
            imageTwo.IsVisible = true;
            imageThree.IsVisible = true;

            imageOneFrame.IsVisible = true;
            imageTwoFrame.IsVisible = true;
            imageThreeFrame.IsVisible = true;
        }

        public async void OnImageOneClicked(object sender, EventArgs e)
        {
            App.ResultsViewModel.PieceGuessed = App.ResultsViewModel.PiecesGuessed.ElementAt(0);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new ResultsPage());
        }

        public async void OnImageTwoClicked(object sender, EventArgs e)
        {
            App.ResultsViewModel.PieceGuessed = App.ResultsViewModel.PiecesGuessed.ElementAt(1);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new ResultsPage());
        }

        public async void OnImageThreeClicked(object sender, EventArgs e)
        {
            App.ResultsViewModel.PieceGuessed = App.ResultsViewModel.PiecesGuessed.ElementAt(2);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new ResultsPage());
        }
    }
}