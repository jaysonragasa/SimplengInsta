using CommunityToolkit.Mvvm.Input;
using SimplengInsta.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace SimplengInsta.ViewModel
{
	public class MainPageViewModel : ViewModelBase
	{
		#region Fields
		Random r = new Random(DateTime.Now.Second);
		private string _title = string.Empty;
		private bool _isBusy = false;
		#endregion

		#region Services
		#endregion

		#region Properties
		public ObservableCollection<PostDetailsModel> Posts { get; set; } = new ObservableCollection<PostDetailsModel>();

		public string Title
		{
			get => _title;
			set { SetProperty(ref _title, value); }
		}
		
		public bool IsBusy
		{
			get => _isBusy;
			set { SetProperty(ref _isBusy, value); }
		}
		#endregion

		#region Commands
		public ICommand RefreshCommand { get; set; }
		public ICommand FollowCommand { get; set; }
		#endregion

		#region Constructor/Initialization
		public MainPageViewModel()
		{
			InitializeCommands();

			// fire and forget
			PopulatePostListAsync();
		}
		#endregion

		#region Overrides
		#endregion

		#region Command Methods
		async Task RefreshAsync()
		{
			await PopulatePostListAsync();
		}

		async Task FollowAsync(PostDetailsModel model)
		{
			await ((Application)App.Current).MainPage.DisplayAlert(string.Empty, $"You are now following {model.UserDetails.Username}", "Ok");
		}
		#endregion

		#region Public
		#endregion

		#region Protected
		#endregion

		#region Abstracts
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		void InitializeCommands()
		{
			RefreshCommand = new AsyncRelayCommand(RefreshAsync);
			FollowCommand = new AsyncRelayCommand<PostDetailsModel>(FollowAsync);
		}

		async Task PopulatePostListAsync()
		{
			try
			{
				List<PostDetailsModel> posts = new List<PostDetailsModel>();

				string[] usernames = "QuantumVoyager|StarryCircuit|NebulaScribe|TechnoNomad|PixelPirate|EchoBlade|CodeVoyage|QuantumQuest|FractalFlare|NovaVoyager|CipherCove|AstroGlyph|BinaryNomad|NebulaVerse|QuantumTrail|StellarCircuit|EchoNomad|PixelVoyage|CipherVoyager|NebulaNomad|AstroCipher|QuantumFlare|StellarNomad|FractalVoyage|NovaCipher|EchoScribe|PixelCircuit|CodeNomad|NebulaFlare|QuantumGlyph|StarryNomad|CipherFlare|NovaNomad|TechnoScribe|PixelScribe|AstroNomad|QuantumCove|StellarGlyph|FractalNomad|CipherScribe|EchoGlyph|CodeFlare|NovaVoyage|PixelNomad|QuantumCircuit|TechnoGlyph|NebulaVoyage|CipherNomad|StarryCipher|AstroScribe".Split('|');
				string[] pictures = "https://picsum.photos/id/20/3670/2462|https://picsum.photos/id/21/3008/2008|https://picsum.photos/id/22/4434/3729|https://picsum.photos/id/23/3887/4899|https://picsum.photos/id/24/4855/1803|https://picsum.photos/id/25/5000/3333|https://picsum.photos/id/26/4209/2769|https://picsum.photos/id/27/3264/1836|https://picsum.photos/id/28/4928/3264|https://picsum.photos/id/29/4000/2670|https://picsum.photos/id/30/1280/901|https://picsum.photos/id/31/3264/4912|https://picsum.photos/id/32/4032/3024|https://picsum.photos/id/33/5000/3333|https://picsum.photos/id/34/3872/2592|https://picsum.photos/id/35/2758/3622|https://picsum.photos/id/36/4179/2790|https://picsum.photos/id/37/2000/1333|https://picsum.photos/id/38/1280/960|https://picsum.photos/id/39/3456/2304".Split('|');
				string[] userdisplaypict = "https://randomuser.me/api/portraits/men/0.jpg|https://randomuser.me/api/portraits/men/24.jpg|https://randomuser.me/api/portraits/women/82.jpg|https://randomuser.me/api/portraits/men/32.jpg|https://randomuser.me/api/portraits/men/89.jpg|https://randomuser.me/api/portraits/men/83.jpg|https://randomuser.me/api/portraits/women/0.jpg|https://randomuser.me/api/portraits/women/94.jpg|https://randomuser.me/api/portraits/women/13.jpg|https://randomuser.me/api/portraits/women/61.jpg|https://randomuser.me/api/portraits/women/70.jpg|https://randomuser.me/api/portraits/men/71.jpg|https://randomuser.me/api/portraits/men/51.jpg|https://randomuser.me/api/portraits/women/28.jpg|https://randomuser.me/api/portraits/men/57.jpg|https://randomuser.me/api/portraits/women/85.jpg|https://randomuser.me/api/portraits/women/59.jpg|https://randomuser.me/api/portraits/men/87.jpg|https://randomuser.me/api/portraits/women/71.jpg|https://randomuser.me/api/portraits/women/25.jpg".Split('|');
				string[] description = "Sunlight filters through dense forest canopies|Mountain streams carve out deep valleys|Desert sands shift with the wind|Rainbows form after summer showers|Birds migrate in intricate patterns|Ocean waves crash against rugged cliffs|Wildflowers bloom in spring meadows|Snowflakes form unique crystalline patterns|Autumn leaves change color and fall|Coral reefs teem with vibrant marine life|The scent of pine fills the air in evergreen forests|Clouds drift lazily across a clear blue sky|Thunderstorms bring refreshing rain|Fireflies light up the night in warm summer evenings|Glaciers slowly reshape the landscape|Cacti store water in their thick, fleshy stems|The sound of crickets fills quiet nights|The Northern Lights paint the polar skies|Rivers meander through lush valleys|Volcanoes create new land with lava flows|Fog drapes over tranquil lakes in the morning".Split('|');
				Posts.Clear();
				
				for (int i = 0; i < 20; i++)
				{
					int ri = r.Next(0, 19);
					int rp = r.Next(0, 19);

					posts.Add(new PostDetailsModel()
					{
						ContentDetails = new ContentDetailsModel()
						{
							ContentType = Enum.ContentTypeEnum.Picture,
							ContentUrl = new List<string>()
							{
								pictures[rp]
							},
							CreatedDate = new DateTime(r.Next(2000, 2024), r.Next(1, 12), r.Next(1, 22)),
							Description = description[rp]
						},
						UserDetails = new UserDetailsModel()
						{
							Username = usernames[ri],
							DisplayPictureUrl = userdisplaypict[ri]
						}
					});
				}

				posts = posts.OrderByDescending(x => x.ContentDetails.CreatedDate).ToList();
				for (int i = 0; i < posts.Count; i++)
				{
					Posts.Add(posts[i]);
				}
			}
			catch( Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			IsBusy = false;
		}
		#endregion
	}
}
