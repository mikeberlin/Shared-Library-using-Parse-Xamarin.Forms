using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

using SharedLibraryParseXamarinForms.Views;

namespace SharedLibraryParseXamarinForms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Parse.ParseClient.Initialize(
				"rqbSPQ9e98SbR52RRrx6IleLbDxxPpixcVQJ29hV",
				"PyLDCgHov0HjUXcpEaieLN4NKeiu4iuuoixgJq2w");

			Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);

			window.RootViewController = new ParseDates ().GetMainPage ().CreateViewController ();
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}