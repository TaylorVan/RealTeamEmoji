using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(TestApp1.Controls.AdviewController), typeof(TestApp1.Droid.Helpers.AdViewRenderer))]
namespace TestApp1.Droid.Helpers
{
    [Obsolete]
    public class AdViewRenderer : ViewRenderer<TestApp1.Controls.AdviewController, AdView>
    {
        string adUnitId = string.Empty;
        //Note you may want to adjust this, see further down.
        AdSize adSize = AdSize.Banner;
        AdView adView;
        AdView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;

            // This is a string in the Resources/values/strings.xml that I added or you can modify it here. This comes from admob and contains a / in it
            adUnitId = "ca-app-pub-3940256099942544/6300978111"; //test banner ad id: ca-app-pub-3940256099942544/6300978111
            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest
                            .Builder()
                            .Build());
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TestApp1.Controls.AdviewController> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                CreateNativeAdControl();
                SetNativeControl(adView);
            }
        }
    }
}