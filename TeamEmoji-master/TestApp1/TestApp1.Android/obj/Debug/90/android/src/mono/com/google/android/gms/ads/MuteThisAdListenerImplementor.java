package mono.com.google.android.gms.ads;


public class MuteThisAdListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.MuteThisAdListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdMuted:()V:GetOnAdMutedHandler:Android.Gms.Ads.IMuteThisAdListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Ads.IMuteThisAdListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", MuteThisAdListenerImplementor.class, __md_methods);
	}


	public MuteThisAdListenerImplementor ()
	{
		super ();
		if (getClass () == MuteThisAdListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Ads.IMuteThisAdListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", "", this, new java.lang.Object[] {  });
	}


	public void onAdMuted ()
	{
		n_onAdMuted ();
	}

	private native void n_onAdMuted ();

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
