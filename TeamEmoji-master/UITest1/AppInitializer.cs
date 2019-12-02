using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Utils;

namespace UITest1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.testapp1").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }

        public class WaitTimes : IWaitTimes

        {

            public TimeSpan GestureWaitTimeout

            {

                get { return TimeSpan.FromMinutes(1); }

            }

            public TimeSpan WaitForTimeout

            {

                get { return TimeSpan.FromMinutes(1); }

            }

            public TimeSpan GestureCompletionTimeout => throw new NotImplementedException();
        }
    }
}