using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Stfalcon.Imageviewer;
using Com.Stfalcon.Imageviewer.Loader;
using FFImageLoading;
using Java.Interop;

namespace Sample
{
	[Activity (Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			Xamarin.Essentials.Platform.Init (this, savedInstanceState);
			SetContentView (Resource.Layout.activity_main);
			var imageView = FindViewById<ImageView> (Resource.Id.imageView1);
			var url = "https://ideas.staticsfly.com/ideas/wp-content/uploads/2019/01/dog-pic-holding-yellow-leaf.jpg";
			ImageService.Instance.LoadUrl (url).Into (imageView);
			var images = new List<string>
			{
				url
			};
			imageView.Click += (s, a) =>
			{
				new StfalconImageViewer.Builder (this, images, new LoadImage ()).WithTransitionFrom(imageView).Show (true);
			};
			
		}
	}

	public class LoadImage : Java.Lang.Object, IImageLoader
	{
		

		public void Disposed ()
		{
		}

		public void DisposeUnlessReferenced ()
		{
		}

		public void Finalized ()
		{
		}

		public void SetJniIdentityHashCode (int value)
		{
		}

		public void SetJniManagedPeerState (JniManagedPeerStates value)
		{
		}

		public void SetPeerReference (JniObjectReference reference)
		{
		}

		void IImageLoader.LoadImage (ImageView p0, Java.Lang.Object p1)
		{
			var url = (string)p1;
			ImageService.Instance.LoadUrl (url)
				.Success((d, f) =>
				{
					var t = "success";
				})
				.Error ((e) =>
				{
					var p = e.Data;
				})
				.Into(p0);
		}
	}
}



