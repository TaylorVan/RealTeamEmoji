﻿using System;
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

            imageOne.Source = "_" + App.ResultsViewModel.PiecesGuessed.ElementAt(0).PartNum + ".jpg";
            imageTwo.Source = "_" + App.ResultsViewModel.PiecesGuessed.ElementAt(1).PartNum + ".jpg";
            imageThree.Source = "_" + App.ResultsViewModel.PiecesGuessed.ElementAt(2).PartNum + ".jpg";

            imageOne.IsVisible = true;
            imageTwo.IsVisible = true;
            imageThree.IsVisible = true;

            imageOneFrame.IsVisible = true;
            imageTwoFrame.IsVisible = true;
            imageThreeFrame.IsVisible = true;

            probability1.Text = (App.ResultsViewModel.Probabilities.ElementAt(0) * 100).ToString("N1") + "%";
            probability2.Text = (App.ResultsViewModel.Probabilities.ElementAt(1) * 100).ToString("N1") + "%";
            probability3.Text = (App.ResultsViewModel.Probabilities.ElementAt(2) * 100).ToString("N1") + "%";

        }

        async void OnImageOneClicked(object sender, EventArgs e)
        {
            App.ResultsViewModel.PieceGuessed = App.ResultsViewModel.PiecesGuessed.ElementAt(0);
            App.ResultsViewModel.PartSelected = 0;
            await Navigation.PushAsync(new ResultsPage());
        }

        async void OnImageTwoClicked(object sender, EventArgs e)
        {
            App.ResultsViewModel.PieceGuessed = App.ResultsViewModel.PiecesGuessed.ElementAt(1);
            App.ResultsViewModel.PartSelected = 1;
            await Navigation.PushAsync(new ResultsPage());
        }

        async void OnImageThreeClicked(object sender, EventArgs e)
        {
            App.ResultsViewModel.PieceGuessed = App.ResultsViewModel.PiecesGuessed.ElementAt(2);
            App.ResultsViewModel.PartSelected = 2;
            await Navigation.PushAsync(new ResultsPage());
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            App.ResultsViewModel.isLoading = false;
            await Navigation.PopAsync();
        }
    }
}