package mono.com.google.android.gms.ads.formats;


public class OnPublisherAdViewLoadedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.formats.OnPublisherAdViewLoadedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPublisherAdViewLoaded:(Lcom/google/android/gms/ads/doubleclick/PublisherAdView;)V:GetOnPublisherAdViewLoaded_Lcom_google_android_gms_ads_doubleclick_PublisherAdView_Handler:Android.Gms.Ads.Formats.IOnPublisherAdViewLoadedListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Ads.Formats.IOnPublisherAdViewLoadedListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", OnPublisherAdViewLoadedListenerImplementor.class, __md_methods);
	}


	public OnPublisherAdViewLoadedListenerImplementor ()
	{
		super ();
		if (getClass () == OnPublisherAdViewLoadedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Ads.Formats.IOnPublisherAdViewLoadedListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", "", this, new java.lang.Object[] {  });
	}


	public void onPublisherAdViewLoaded (com.google.android.gms.ads.doubleclick.PublisherAdView p0)
	{
		n_onPublisherAdViewLoaded (p0);
	}

	private native void n_onPublisherAdViewLoaded (com.google.android.gms.ads.doubleclick.PublisherAdView p0);

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
