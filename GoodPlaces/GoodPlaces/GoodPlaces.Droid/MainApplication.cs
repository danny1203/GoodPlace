// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using System;

namespace GoodPlaces.Droid
{
	//You can specify additional application information in this attribute
#if DEBUG
    [Application(Debuggable = true)]
#else
	[Application(Debuggable = false)]
#endif
	public class MainApplication : Application, Application.IActivityLifecycleCallbacks
	{
		public MainApplication(IntPtr handle, JniHandleOwnership transer)
		  : base(handle, transer)
		{
		}

		public override void OnCreate()
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ5NTFAMzEzNjJlMzMyZTMwTlBBdjNSTy9wa0liRkpva2N2MC9JYlhIVlBLVDJWS2h6bXhVcHV1QXlqTT0=");
			base.OnCreate();

			RegisterActivityLifecycleCallbacks(this);
			//A great place to initialize Xamarin.Insights and Dependency Services!
		}

		public override void OnTerminate()
		{
			base.OnTerminate();

			UnregisterActivityLifecycleCallbacks(this);
		}

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivityDestroyed(Activity activity)
		{
		}

		public void OnActivityPaused(Activity activity)
		{
		}

		public void OnActivityResumed(Activity activity)
		{
			CrossCurrentActivity.Current.Activity = activity;
		}

		public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
		{

		}

		public void OnActivityStarted(Activity activity)
		{

		}

		public void OnActivityStopped(Activity activity)
		{

		}

	}
}