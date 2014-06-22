using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using Parse;
using SharedLibraryParseXamarinForms.ViewModels;

namespace SharedLibraryParseXamarinForms.Views
{
	public class ParseDates : ContentPage
	{
		#region Public Methods

		public Page GetMainPage () {
			BindingContext = new ParseViewModel ();

			if (ViewModel != null && ViewModel.CanLoadMore && !ViewModel.IsBusy && ViewModel.Dates.Count <= 0) {
				ViewModel.LoadDatesCommand.Execute (null);
			}

			var stack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(0, 8, 0, 8),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
			};

			var loadingActivity = (new ActivityIndicator {
				Color = Color.Black,
				IsEnabled = true,
			});
			loadingActivity.SetBinding (ActivityIndicator.IsVisibleProperty, "IsBusy");
			loadingActivity.SetBinding (ActivityIndicator.IsRunningProperty, "IsBusy");

			stack.Children.Add (loadingActivity);

			var listView = new ListView {
				BackgroundColor = Color.Silver,
			};
			listView.ItemsSource = ViewModel.Dates;

			var cell = new DataTemplate (typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "DateStr");
			listView.ItemTemplate = cell;

			stack.Children.Add (listView);

			return new ContentPage {
				BackgroundColor = Color.Transparent,
				Content = stack,
			};
		}

		#endregion

		#region Overrides

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy || ViewModel.Dates.Count > 0)
				return;

			ViewModel.LoadDatesCommand.Execute (null);
		}

		#endregion

		#region Private Methods

		private ParseViewModel ViewModel
		{
			get { return BindingContext as ParseViewModel; }
		}

		#endregion
	}
}