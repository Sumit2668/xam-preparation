package md5f99295a6c1318db7114acd3ab8f54132;


public class CustomCircleMapRenderer
	extends md55b943cb46934695d066180d3c9f40d32.MapRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App3.Droid.PageRenderer.CustomCircleMapRenderer, App3.Android", CustomCircleMapRenderer.class, __md_methods);
	}


	public CustomCircleMapRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomCircleMapRenderer.class)
			mono.android.TypeManager.Activate ("App3.Droid.PageRenderer.CustomCircleMapRenderer, App3.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CustomCircleMapRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomCircleMapRenderer.class)
			mono.android.TypeManager.Activate ("App3.Droid.PageRenderer.CustomCircleMapRenderer, App3.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomCircleMapRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomCircleMapRenderer.class)
			mono.android.TypeManager.Activate ("App3.Droid.PageRenderer.CustomCircleMapRenderer, App3.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}

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
