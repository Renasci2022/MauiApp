namespace SimpleApp;

using SimpleApp.Models;
using SimpleApp.Data;

public partial class AddPostPage : ContentPage
{
    private readonly DatabaseManager _databaseManager = new DatabaseManager();

    public AddPostPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var post = new Post
        {
            Title = titleEntry.Text,
            Content = contentEditor.Text
        };

        _databaseManager.AddPost(post);

        await DisplayAlert("Success", "Post added successfully", "OK");
        await Navigation.PopAsync();
    }
}
