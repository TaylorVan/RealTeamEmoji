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
            app.WaitForElement(x => x.Marked("Enter"));
            app.Tap(x => x.Marked("Enter"));
        }

        [Test]
        public void TakingPhoto()
        {
            app.Tap(x => x.Marked("Enter"));
            app.WaitForElement(x => x.Marked("Take Photo"));
            app.Tap(x => x.Marked("Take Photo"));
            app.WaitForElement(x => x.Marked("Part Idenified:"), "Too slow to take photo", TimeSpan.FromSeconds(1));
        }

        [Test]
        public void UploadingPhoto()
        {
            app.Tap(x => x.Marked("Enter"));
            app.WaitForElement(x => x.Marked("Choose From Gallery"));
            app.Tap(x => x.Marked("Choose From Gallery"));
            app.WaitForElement(x => x.Marked("Part Idenified:"), "Too slow to take photo", TimeSpan.FromSeconds(30));
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
