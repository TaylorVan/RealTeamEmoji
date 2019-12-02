using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestApp1.ViewModels;
using TestApp1.Models;
using SQLite;
using System.Windows.Input;

namespace TestApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(OpenBrowser);

        public ResultsPage()
        {
            InitializeComponent();
            BindingContext =  App.ResultsViewModel;
            App.ResultsViewModel.isLoading = false;

            if (App.ResultsViewModel.PieceNotIdentified == false)
            {
                imageToIdentify.Source = App.ResultsViewModel.PieceGuessed.Url;
                imageToIdentify.IsVisible = true;
                displayName.Text = "Name: " + App.ResultsViewModel.PieceGuessed.PartName;
                displayName.IsVisible = true;
                displayPartId.Text = "Part ID: " + App.ResultsViewModel.PieceGuessed.PartNum;
                displayPartId.IsVisible = true;
                displayCatagory.Text = "Category: " + App.ResultsViewModel.PieceGuessed.Catagory;
                displayCatagory.IsVisible = true;
                link.CommandParameter = "https://rebrickable.com/parts/" + App.ResultsViewModel.PieceGuessed.PartNum + "/#buy_parts";
                displayLink.IsVisible = true;
                displayProbability.IsVisible = true;
                displayFail.IsVisible = false;
                BindingContext = this;
            }
            else
            {
                imageToIdentify.IsVisible = false;
                displayName.IsVisible = false;
                displayPartId.IsVisible = false;
                displayCatagory.IsVisible = false;
                displayLink.IsVisible = false;
                displayProbability.IsVisible = false;
                displayFail.IsVisible = true;

            }

            displayProbability.Text = "Probability: " + App.ResultsViewModel.Probability.ToString();

        }

        void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            App.ResultsViewModel.isLoading = false;
            await Navigation.PushAsync(new MainPage());
        }

    }
}