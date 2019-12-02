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
using Xamarin.Essentials;

namespace TestApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Boolean testing = false;

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
            //Skips the camera/gallery while testing
            if (testing)
            {
                Piece pieceTest = GetPieceById("61071");
                App.ResultsViewModel.PieceGuessed = pieceTest;
                await Navigation.PushAsync(new ResultsPage());
                return;
            }

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
            //Skips the camera/gallery while testing
            if (testing)
            {
                await Navigation.PushAsync(new ResultsPage());
            }

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

        private Piece GetPieceById(string id)
        {
            var db = App.PieceDatabase.GetAllPieces();

            return db.Result.Find(t => t.PartNum == id);
        }
        //Event handler for the back button
        private async void ReturnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenu());
        }

        private async void BookButton_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri("https://www.amazon.ca/EV3-Brainy-Kids-MINDSTORMS-Robotics-ebook/dp/B0779M98B8/ref=sr_1_1?keywords=ev3+brainy+kids&qid=1575324613&sr=8-1"), BrowserLaunchMode.SystemPreferred);

        }

        //Test function for checking if piece object is correctly passing
        public Piece GetPieceTest()
        {
            Piece piece = new Piece();
            piece.Catagory = "Beam";
            piece.PartName = "7 Beam";
            piece.PartNum = "1234";
            piece.Url = "Test.com";
            return piece;
        }


        //Function to check the probability of the neural network
        public bool ProbabilityTest(double probability)
        {
            if (probability > 0.6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
