package mono.com.google.android.gms.ads.formats;


public class UnifiedNativeAd_OnUnifiedNativeAdLoadedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.formats.UnifiedNativeAd.OnUnifiedNativeAdLoadedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onUnifiedNativeAdLoaded:(Lcom/google/android/gms/ads/formats/UnifiedNativeAd;)V:GetOnUnifiedNativeAdLoaded_Lcom_google_android_gms_ads_formats_UnifiedNativeAd_Handler:Android.Gms.Ads.Formats.UnifiedNativeAd/IOnUnifiedNativeAdLoadedListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Ads.Formats.UnifiedNativeAd+IOnUnifiedNativeAdLoadedListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", UnifiedNativeAd_OnUnifiedNativeAdLoadedListenerImplementor.class, __md_methods);
	}


	public UnifiedNativeAd_OnUnifiedNativeAdLoadedListenerImplementor ()
	{
		super ();
		if (getClass () == UnifiedNativeAd_OnUnifiedNativeAdLoadedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Ads.Formats.UnifiedNativeAd+IOnUnifiedNativeAdLoadedListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", "", this, new java.lang.Object[] {  });
	}


	public void onUnifiedNativeAdLoaded (com.google.android.gms.ads.formats.UnifiedNativeAd p0)
	{
		n_onUnifiedNativeAdLoaded (p0);
	}

	private native void n_onUnifiedNativeAdLoaded (com.google.android.gms.ads.formats.UnifiedNativeAd p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
