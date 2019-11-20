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

namespace TestApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
            BindingContext = new ResultsViewModel();

            imageToIdentify.Source = App.ResultsViewModel.PieceGuessed.Url;
            displayName.Text = "Name: " + App.ResultsViewModel.PieceGuessed.PartName;
            displayPartId.Text = "Part ID: " + App.ResultsViewModel.PieceGuessed.PartNum;
            displayCatagory.Text = App.ResultsViewModel.PieceGuessed.Catagory;
        }
    }
}