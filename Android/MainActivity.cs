using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;

using SharedLibraryParseXamarinForms.Views;

namespace SharedLibraryParseXamarinForms.Android
{
	[Activity (Label = "Shared-Library-Parse-Xamarin-Forms.Android.Android", MainLauncher = true)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Parse.ParseClient.Initialize("rqbSPQ9e98SbR52RRrx6IleLbDxxPpixcVQJ29hV", "PyLDCgHov0HjUXcpEaieLN4NKeiu4iuuoixgJq2w");

			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage (new ParseDates ().GetMainPage ());
		}
	}
}