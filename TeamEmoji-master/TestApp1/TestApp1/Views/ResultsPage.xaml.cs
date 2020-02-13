using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestApp1.ViewModels;
using SQLite;
using System.Windows.Input;
using Xamarin.Essentials;

namespace TestApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(OpenBrowser);

        public ResultsPage()
        {
            InitializeComponent();
            BindingContext = App.ResultsViewModel;
            App.ResultsViewModel.isLoading = false;

            if (App.ResultsViewModel.PieceNotIdentified == false)
            {

                string description = "";
                //Set description
                switch (App.ResultsViewModel.PieceGuessed.Catagory)
                {
                    case "Connector Pegs":
                        description = "Connector pegs are the hardest working LEGO Technic part. These are used to connect two parts.";
                        break;
                    case "Beams":
                        description = "Beams are the basic building blocks of the robot.";
                        break;
                    case "Angular Beams":
                        description = "Angular Beams are used when you want to change direction when joining parts together.";
                        break;
                    case "Axles":
                        description = "Axles are used with motors and wheels";
                        break;
                    case "Hubs":
                        description = "Hubs are used with tires to form wheels.";
                        break;
                    case "Tires":
                        description = "Rubber tires provide grip to the wheels.";
                        break;
                    case "Frames":
                        description = "Frames are great for mounting sensors and motors.";
                        break;
                    case "Gears":
                        description = "Gears are used with motors to change speed and power and to create claws and grippers.";
                        break;
                    case "Bushes":
                        description = "Bushes and bushings are designed to keep axles and pieces attached to axles in place.";
                        break;
                    case "Non-Lego Pieces":
                        description = "These pieces are unique and have special uses.";
                        break;
                }

                imageToIdentify.Source = "_" + App.ResultsViewModel.PieceGuessed.PartNum + ".jpg";
                imageToIdentify.IsVisible = true;
                displayName.Text = App.ResultsViewModel.PieceGuessed.PartName;
                displayName.IsVisible = true;
                displayPartId.Text = "Part ID: " + App.ResultsViewModel.PieceGuessed.PartNum;
                displayPartId.IsVisible = true;
                displayCatagory.Text = "Category: " + App.ResultsViewModel.PieceGuessed.Catagory;
                displayCatagory.IsVisible = true;
                displayDescription.Text = description;
                displayDescription.IsVisible = true;
                link.CommandParameter = "https://rebrickable.com/parts/" + App.ResultsViewModel.PieceGuessed.PartNum + "/#buy_parts";
                displayLink.IsVisible = true;
                displayProbability.IsVisible = true;
                displayFail.IsVisible = false;
                probabilityFrame.IsVisible = true;
                imageFrame.IsVisible = true;
                resultsFrame.IsVisible = true;
                BindingContext = this;
            }
            else
            {
                imageToIdentify.IsVisible = false;
                displayName.IsVisible = false;
                displayPartId.IsVisible = false;
                displayCatagory.IsVisible = false;
                displayDescription.IsVisible = false;
                displayLink.IsVisible = false;
                displayProbability.IsVisible = false;
                displayFail.IsVisible = true;
                probabilityFrame.IsVisible = false;
                imageFrame.IsVisible = false;
                resultsFrame.IsVisible = false;

            }

            var current = Connectivity.NetworkAccess;

            if (current != NetworkAccess.Internet)
            {
                displayLink.IsVisible = false;
            }
            var percent = App.ResultsViewModel.Probabilities.ElementAt(App.ResultsViewModel.PartSelected) * 100;

            displayProbability.Text = "Probability: " + percent.ToString("N1") + "%";

        }

        void OpenBrowser(string url)
        {
            Device.OpenUri(new Uri(url));
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            App.ResultsViewModel.isLoading = false;
            await Navigation.PopAsync();
        }

    }
}