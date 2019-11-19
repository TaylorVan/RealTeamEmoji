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
            List<Part> parts = new List<Part>
            {
                new Part("2736", 71, 6, 6),
                new Part("Technic Pin with Friction Ridges Lengthwise and Center Slots", "https://cdn.rebrickable.com/media/thumbs/parts/elements/4121715.jpg/250x250p.jpg?1561404147.1748974",  "2780", 0, 95, 10),
                new Part("2815", 0, 3, 0),
                new Part("3649", 71, 2, 7),
                new Part("3673", 71, 4, 0),
                new Part("3705", 0, 4, 10),
                new Part("3706", 0, 9, 10),
                new Part("3707", 0, 2, 10),
                new Part("3708", 0, 2, 0),
                new Part("3713", 4, 9, 10),
                new Part("3737", 0, 2, 10),
                new Part("3749", 19, 8, 0),
                new Part("4019", 71, 4, 0),
                new Part("4185", 71, 3, 10),
                new Part("4519", 71, 14, 10),
                new Part("4716", 71, 2, 5),
                new Part("6536", 4, 8, 10),
                new Part("6536", 71, 8, 0),
                new Part("6558", 1, 38, 10),
                new Part("6575", 0, 2, 23),
                new Part("6587", 28, 4, 0),
                new Part("6587", 28, 2, 0),
                new Part("6589", 19, 1, 10),
                new Part("6589", 19, 2, 0),
                new Part("6628", 0, 6, 5),
                new Part("6629", 0, 4, 0),
                new Part("6632", 71, 1, 14),
                new Part("10916", 0, 1, 0),
                new Part("10928", 72, 4, 11),
                new Part("11145", 0, 4, 10),
                new Part("11145", 0, 4, 10),
                new Part("13710", 9999, 1, 0),
                new Part("18575", 0, 4, 0),
                new Part("24505", 72, 2, 10),
                new Part("32009", 0, 12, 10),
                new Part("32013", 4, 4, 0),
                new Part("32014", 4, 1, 18),
                new Part("32034", 4, 6, 10),
                new Part("32039", 71, 2, 7),
                new Part("32054", 4, 10, 20),
                new Part("32062", 4, 12, 10),
                new Part("32068", 71, 4, 10),
                new Part("32072", 0, 4, 10),
                new Part("32073", 71, 9, 0),
                new Part("32073", 71, 6, 0),
                new Part("32138", 71, 4, 17),
                new Part("32140", 0, 8, 10),
                new Part("32192", 4, 4, 0),
                new Part("32198", 19, 1, 10),
                new Part("32269", 0, 2, 0),
                new Part("32270", 0, 2, 18),
                new Part("32271", 71, 4, 9),
                new Part("32278", 0, 4, 11),
                new Part("32291", 4, 2, 12),
                new Part("32293", 0, 4, 12),
                new Part("32316", 0, 10, 0),
                new Part("32316", 71, 4, 0),
                new Part("32348", 0, 4, 10),
                new Part("32449", 0, 2, 19),
                new Part("32498", 0, 5, 10),
                new Part("32523", 0, 12, 17),
                new Part("32524", 71, 4, 10),
                new Part("32524", 0, 6, 0),
                new Part("32525", 4, 4, 0),
                new Part("32525", 71, 4, 0),
                new Part("32526", 71, 2, 10),
                new Part("32526", 0, 6, 0),
                new Part("32556", 19, 4, 10),
                new Part("32556", 19, 6, 0),
                new Part("32905", 71, 2, 11),
                new Part("40490", 0, 8, 5),
                new Part("41239", 0, 4, 10),
                new Part("41669", 4, 6, 20),
                new Part("41678", 4, 4, 10),
                new Part("41897", 0, 2, 0),
                new Part("42003", 4, 14, 10),
                new Part("42610", 71, 4, 9),
                new Part("43093", 1, 28, 19),
                new Part("44294", 71, 2, 0),
                new Part("44309", 0, 4, 0),
                new Part("44809", 4, 2, 10),
                new Part("45590", 0, 4, 0),
                new Part("48989", 71, 12, 8),
                new Part("50951", 0, 2, 0),
                new Part("53550", 0, 1, 14),
                new Part("53992", 0, 2, 0),
                new Part("54187", 0, 1, 0),
                new Part("54190", 47, 1, 0),
                new Part("54271", 0, 1, 0),
                new Part("54821", 4, 3, 10),
                new Part("55013", 72, 6, 6),
                new Part("55615", 71, 4, 10),
                new Part("55805", 0, 2, 10),
                new Part("55806", 0, 1, 7),
                new Part("56145", 0, 4, 22),
                new Part("56908", 71, 2, 0),
                new Part("57519", 0, 4, 10),
                new Part("57585", 71, 1, 9),
                new Part("59426", 72, 2, 10),
                new Part("59443", 4, 3, 10),
                new Part("60483", 0, 10, 19),
                new Part("60484", 0, 4, 10),
                new Part("60485", 71, 1, 0),
                new Part("61070", 15, 1, 0),
                new Part("61071", 15, 1, 0),
                new Part("62462", 71, 2, 10),
                new Part("63869", 71, 2, 8),
                new Part("64178", 71, 2, 10),
                new Part("64179", 71, 2, 10),
                new Part("64391", 15, 3, 0),
                new Part("64392", 0, 1, 0),
                new Part("64393", 15, 3, 0),
                new Part("64681", 15, 3, 0),
                new Part("64682", 0, 1, 0),
                new Part("64683", 15, 3, 0),
                new Part("72156", 15, 1, 10),
                new Part("85544", 4, 1, 0),
                new Part("87080", 0, 1, 0),
                new Part("87082", 71, 6, 7),
                new Part("87083", 72, 4, 8),
                new Part("87086", 0, 1, 0),
                new Part("87408", 0, 1, 9),
                new Part("88323", 0, 54, 0),
                new Part("92907", 71, 2, 27),
                new Part("92911", 72, 1, 21),
                new Part("95648", 15, 1, 10),
                new Part("95650", 15, 1, 15),
                new Part("95652", 15, 1, 12),
                new Part("95654", 71, 1, 0),
                new Part("95656", 72, 1, 0),
                new Part("95658", 15, 2, 7),
                new Part("98347", 15, 4, 0),
                new Part("99008", 19, 3, 0),
                new Part("99009", 71, 2, 0),
                new Part("99010", 0, 2, 0),
                new Part("99380", 15, 1, 0),
                new Part("99455", 15, 1, 10),
                new Part("99773", 71, 4, 0),
                new Part("99948", 9999, 1, 0),
                new Part("32005a", 0, 2, 31),
                new Part("32123b", 14, 11, 10),
                new Part("33299a", 0, 2, 11),
                new Part("3648b", 72, 4, 21),
                new Part("95646c01", 15, 1, 11),
                new Part("98568p02", 4, 6, 7)
            };

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
                    Part p = parts.Find(t => t.partId == partId);
                    App.ResultsViewModel.PartGuessed = p;

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
                    Part p = parts.Find(t => t.partId == partId);
                    App.ResultsViewModel.PartGuessed = p;

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
