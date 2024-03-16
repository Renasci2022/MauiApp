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
		if (e.CurrentSelection.FirstOrDefault() is Post { Content: { } } currentSelection)
		{
			var detailsPage = new DetailsPage(currentSelection.Content, currentSelection.ImageUrl ?? string.Empty);
			Navigation.PushAsync(detailsPage);
		}
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddPostPage());
	}
}
