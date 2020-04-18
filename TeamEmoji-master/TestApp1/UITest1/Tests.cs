using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void EnterMenu()
        {

            app.Tap(x => x.Marked("button"));
        }

        [Test]
        public void TakingPhoto()
        {
            app.Tap(x => x.Marked("button"));
            app.WaitForElement(x => x.Marked("takephoto"));
            app.Tap(x => x.Marked("takephoto"));
            app.WaitForElement(x => x.Marked("finished"), "Too slow to take photo", TimeSpan.FromSeconds(1000));
        }

        [Test]
        public void UploadingPhoto()
        {
            app.Tap(x => x.Marked("Enter"));
            app.WaitForElement(x => x.Marked("Choose From Gallery"));
            app.Tap(x => x.Marked("Choose From Gallery"));
            app.WaitForElement(x => x.Marked("Part Identified:"), "Too slow to take photo", TimeSpan.FromSeconds(30));
        }

        [Test]
        public void LinkAppears()
        {

        }

        [Test]
        public void photoSizeCheck()
        {
        }

        [Test]
        public void PhotoExtensionCheck()
        {

        }
    }
}
