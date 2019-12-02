using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using TestApp1.ViewModels;
using Xam.Plugins.OnDeviceCustomVision;
using Plugin.Media.Abstractions;

namespace TestApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            BindingContext = App.ResultsViewModel;
            App.ResultsViewModel.IsLoading = false;

        }

        //Event handler for the Take Photo button
        //Get image from camera >> classify image >> Set piece in viewmodel >> Go to results
        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {

            MediaFile file = await TakePhoto();

            if (file == null)
                return;

            App.ResultsViewModel.IsLoading = true;

            Piece piece = await ClassifyImage(file);
            if (piece == null)
            {
                App.ResultsViewModel.PieceGuessed = null;
                App.ResultsViewModel.PieceNotIdentified = true;
            }
            else
            {
                App.ResultsViewModel.PieceGuessed = piece;
            }

            file.Dispose();
            App.ResultsViewModel.IsLoading = false;
            await Navigation.PushAsync(new ResultsPage());
        }

        //Event handler for the Pick Photo button
        //Get image from gallery >> classify image >> Set piece in viewmodel >> Go to results
        private async void PickPhoto_Clicked(object sender, EventArgs e)
        {

            MediaFile file = await PickPhoto();

            if (file == null)
                return;

            Piece piece = await ClassifyImage(file);
            if(piece == null)
            {
                App.ResultsViewModel.PieceGuessed = null;
                App.ResultsViewModel.PieceNotIdentified = true;
            }
            else
            {
                App.ResultsViewModel.PieceGuessed = piece;
            }

            //stream = file.GetStream();
            file.Dispose();

            App.ResultsViewModel.IsLoading = false;
            //image.Source = ImageSource.FromStream(() => stream);
            await Navigation.PushAsync(new ResultsPage());

        }

        //Runs Xamarin.Plugins.Media TakePhotoAsync method to get a photo, of type MediaFile, from the camera
        //Returns a Task with result type of MediaFile image or NULL if image failed
        //To access the result's type, either convert it by using {  MediaFile result = await TakePhoto() }
        //      or access it directly with {  var task,     result.Result   }
        private async Task<MediaFile> TakePhoto()
        {
            MediaFile file = null;

            await Task.Run(async () =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble. Sorry", "OK");
                    return;
                }
                try
                {
                    App.ResultsViewModel.OverrideBackButton = true;
                    App.ResultsViewModel.IsLoading = true;
                    file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        //SaveToAlbum = saveToGallery.IsToggled
                    });
                }
                catch {}
            });

            return file;
        }

        //Runs Xamarin.Plugins.Media PickPhotoAsync method to get a photo, of type MediaFile, from the gallery
        //Returns a Task with result type of MediaFile image or NULL if image failed
        private async Task<MediaFile> PickPhoto()
        {
            MediaFile file = null;

            await Task.Run(async () =>
            {

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                try
                {
                    //Stream stream = null;
                    App.ResultsViewModel.IsLoading = true;
                    file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);
                }
                catch {}

            });
            return file;
        }

        //Get piece from neural network
        //Calls OnDiviceCustomVision's ClassifyImage function to get a list of parts that are then ordered
        //by probability. The most likely piece is returned
        private async Task<Piece> ClassifyImage(MediaFile file)
        {
            App.ResultsViewModel.PieceNotIdentified = false;

            if (file == null)
                return null;

            var tags = await CrossImageClassifier.Current.ClassifyImage(file.GetStream());
            App.ResultsViewModel.Probability = tags.OrderByDescending(t => t.Probability).First().Probability;

            //Check if the highest probability meets the minimum threshold
            if (App.ResultsViewModel.Probability < 0.6)
            {
                return null;
            }

            var partId = tags.OrderByDescending(t => t.Probability).First().Tag;
            var db = App.PieceDatabase.GetAllPieces();


            return db.Result.Find(t => t.PartNum == partId);
        }

        //Event handler for the back button
        private async void ReturnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenu());
        }


    }
}
