using SimpleApp.Models;

namespace SimpleApp;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(string content, string imageUrl)
    {
        InitializeComponent();
        postContent.Text = content;
        postImage.Source = imageUrl;
    }
}
