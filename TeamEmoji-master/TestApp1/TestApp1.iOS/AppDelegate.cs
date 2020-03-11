using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Foundation;
using UIKit;
using Xam.Plugins.OnDeviceCustomVision;

namespace TestApp1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "lego_parts.db3");
            var appDir = NSBundle.MainBundle.ResourcePath;
            var seedFile = Path.Combine(appDir, "lego_parts.db3");

            if (!File.Exists(dbPath))
            {
                File.Copy(seedFile, dbPath);
            }
            else
            {
                Console.WriteLine("Database already exists on device");
            }


            var modelPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "IphoneTestModel.mlmodel");
            seedFile = Path.Combine(appDir, "IphoneTestModel.mlmodel");

            if (!File.Exists(modelPath))
            {
                File.Copy(seedFile, modelPath);
            }
            else
            {
                Console.WriteLine("Model already exists on device");
            }

            iOSImageClassifier.Init("IphoneTestModel");

            return base.FinishedLaunching(app, options);
        }
    }
}
