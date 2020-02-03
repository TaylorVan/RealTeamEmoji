package mono.com.google.android.gms.ads.mediation;


public class OnImmersiveModeUpdatedListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.ads.mediation.OnImmersiveModeUpdatedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onImmersiveModeUpdated:(Z)V:GetOnImmersiveModeUpdated_ZHandler:Android.Gms.Ads.Mediation.IOnImmersiveModeUpdatedListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite\n" +
			"";
		mono.android.Runtime.register ("Android.Gms.Ads.Mediation.IOnImmersiveModeUpdatedListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", OnImmersiveModeUpdatedListenerImplementor.class, __md_methods);
	}


	public OnImmersiveModeUpdatedListenerImplementor ()
	{
		super ();
		if (getClass () == OnImmersiveModeUpdatedListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.Gms.Ads.Mediation.IOnImmersiveModeUpdatedListenerImplementor, Xamarin.GooglePlayServices.Ads.Lite", "", this, new java.lang.Object[] {  });
	}


	public void onImmersiveModeUpdated (boolean p0)
	{
		n_onImmersiveModeUpdated (p0);
	}

	private native void n_onImmersiveModeUpdated (boolean p0);

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
