using SimpleApp.Data;
using SimpleApp.Models;

namespace SimpleApp;

public partial class MainPage : ContentPage
{
	private readonly DatabaseManager _databaseManager;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();

		_databaseManager = new DatabaseManager();
		LoadPosts();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		LoadPosts();
	}

	private void LoadPosts()
	{
		var posts = _databaseManager.GetPosts();
		BindingContext = new MainViewModel { Posts = posts };
	}

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Post selectedPost)
		{
			var title = selectedPost.Title ?? "No title";
			var content = selectedPost.Content ?? String.Empty;

			var detailsPage = new DetailsPage(title, content);
			Navigation.PushAsync(detailsPage);
		}
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPostPage());
	}
}
