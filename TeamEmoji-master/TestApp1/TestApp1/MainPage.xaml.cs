using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using TestApp1.Models;
using Xam.Plugins.OnDeviceCustomVision;

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


        //Event handler for the Take Photo button
        //Get image from camera >> classify image >> Set piece in viewmodel >> Go to results
        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {

            MediaFile file = await TakePhoto();

            if (file == null)
                return;

            App.ResultsViewModel.IsLoading = true;

            Piece piece = await ClassifyImage(file.GetStream());
            if (piece == null)
            {

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

            Piece piece = await ClassifyImage(file.GetStream());
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
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        SaveToAlbum = saveToGallery.IsToggled
                    });

                    if (file == null)
                        return;

                    //await DisplayAlert("File Location", (saveToGallery.IsToggled ? file.AlbumPath : file.Path), "OK");

                    var tags = await CrossImageClassifier.Current.ClassifyImage(file.GetStream());
                    var partId = tags.OrderByDescending(t => t.Probability).First().Tag;
                    var db = App.PieceDatabase.GetAllPieces();
                    Piece p = db.Result.Find(t => t.PartNum == partId);
                    //Part p = parts.Find(t => t.partId == partId);
                    App.ResultsViewModel.PieceGuessed = p;

                    image.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                    await Navigation.PushAsync(new ResultsPage());
                }
                catch //(Exception ex)
                {
                    // Xamarin.Insights.Report(ex);
                    // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
                }
            };

            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                try
                {
                    Stream stream = null;
                    var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);


        //Get piece from neural network
        //Calls OnDiviceCustomVision's ClassifyImage function to get a list of parts that are then ordered
        //by probability. The most likely piece is returned
        public async Task<Piece> ClassifyImage(Stream file)
        {
            App.ResultsViewModel.PieceNotIdentified = false;

                    var tags = await CrossImageClassifier.Current.ClassifyImage(file.GetStream());
                    var partId = tags.OrderByDescending(t => t.Probability).First().Tag;
                    var db = App.PieceDatabase.GetAllPieces();
                    Piece p = db.Result.Find(t => t.PartNum == partId);
                    //Part p = parts.Find(t => t.partId == partId);
                    App.ResultsViewModel.PieceGuessed = p;

            var tags = await CrossImageClassifier.Current.ClassifyImage(file);
            App.ResultsViewModel.Probability = tags.OrderByDescending(t => t.Probability).First().Probability;

            //Check if the highest probability meets the minimum threshold
            if (!probabilityTest(App.ResultsViewModel.Probability))
            {
                return null;
            }

                    image.Source = ImageSource.FromStream(() => stream);
                    await Navigation.PushAsync(new ResultsPage());

                }
                catch //(Exception ex)
                {
                    // Xamarin.Insights.Report(ex);
                    // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
                }
            };

        }

        //Event handler for the back button
        private async void ReturnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainMenu());
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
        public bool probabilityTest(double probability)
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
