using SimpleApp.Data;
using SimpleApp.Models;

namespace SimpleApp;

public partial class MainPage : ContentPage
{
	private readonly DatabaseManager _databaseManager;

	public MainPage()
	{
		InitializeComponent();
		_databaseManager = new DatabaseManager();
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
}
