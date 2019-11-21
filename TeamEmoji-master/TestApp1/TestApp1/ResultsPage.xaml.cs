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
            BindingContext = new ResultsViewModel();

            imageToIdentify.Source = App.ResultsViewModel.PieceGuessed.Url;
            displayName.Text = "Name: " + App.ResultsViewModel.PieceGuessed.PartName;
            displayPartId.Text = "Part ID: " + App.ResultsViewModel.PieceGuessed.PartNum;
            displayCatagory.Text = App.ResultsViewModel.PieceGuessed.Catagory;
            link.CommandParameter = "https://rebrickable.com/parts/" + App.ResultsViewModel.PieceGuessed.PartNum + "/#buy_parts";
            BindingContext = this;
        }

        void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }

    }
}