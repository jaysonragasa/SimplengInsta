using CommunityToolkit.Mvvm.ComponentModel;

namespace SimplengInsta.ViewModel
{
	public class SecondViewModel : ObservableObject
	{
		string _title = string.Empty;
		public string Title
		{
			get => _title;
			set { SetProperty(ref _title, value); }
		}

		public SecondViewModel()
        {
			Title = "Second View Model";
        }
    }
}
