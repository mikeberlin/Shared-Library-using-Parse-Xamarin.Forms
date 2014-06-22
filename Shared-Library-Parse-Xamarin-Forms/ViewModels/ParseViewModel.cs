using System;
using System.Collections.ObjectModel;

using SharedLibraryParseXamarinForms.Models;

using Parse;
using Xamarin.Forms;

namespace SharedLibraryParseXamarinForms.ViewModels
{
	public class ParseViewModel : BaseViewModel
	{
		#region Properties, Commands, etc.

		public ObservableCollection<ParseDate> Dates { get; set; }

		private Command loadDatesCommand;

		public Command LoadDatesCommand {
			get { return loadDatesCommand ?? (loadDatesCommand = new Command (ExecuteLoadDatesCommand)); }
		}

		#endregion

		#region Constructors

		public ParseViewModel ()
		{
			Dates = new ObservableCollection<ParseDate> ();
		}

		#endregion

		#region Private Methods

		private async void ExecuteLoadDatesCommand ()
		{
			if (IsBusy) return;
			IsBusy = true;

			try {
				Dates.Clear();

				var query = ParseObject.GetQuery ("Date");
				var dates = await query.FindAsync ();
				ParseDate date;

				foreach (var parseDate in dates) {
					date = new ParseDate (parseDate);
					Dates.Add (date);
				}
			} catch (Exception ex) {
				var page = new ContentPage();
				page.DisplayAlert ("Error", "Unable to load dates from Parse. :(", "OK", null);
			}

			IsBusy = false;
		}

		#endregion
	}
}