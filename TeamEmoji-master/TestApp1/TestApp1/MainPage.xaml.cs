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


            takePhoto.Clicked += async (sender, args) =>
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


                    if (file == null)
                        return;

                    var tags = await CrossImageClassifier.Current.ClassifyImage(file.GetStream());
                    var partId = tags.OrderByDescending(t => t.Probability).First().Tag;
                    var db = App.PieceDatabase.GetAllPieces();
                    Piece p = db.Result.Find(t => t.PartNum == partId);
                    //Part p = parts.Find(t => t.partId == partId);
                    App.ResultsViewModel.PieceGuessed = p;

                    /*
                    getPartInfo(p);
                    //Loop through first three guesses
                    var n = 0;
                    info.Text = "\n";
                    while (n < 3)
                    {
                        //Get probability and round to 2 decimals/convert to string
                        var probability = tags.OrderByDescending(t => t.Probability).ElementAt(n).Probability * 100;
                        var probStr = probability.ToString("#.##");
                        //Set Label on MainPage
                        info.Text += n + 1 + ". " + tags.OrderByDescending(t => t.Probability).ElementAt(n).Tag + " with " + probStr + "% confidence\n";
                        ++n;
                    }
                    */

                    stream = file.GetStream();
                    file.Dispose();

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
    }
}
