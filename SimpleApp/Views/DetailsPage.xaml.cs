using SimpleApp.Models;

namespace SimpleApp;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(string title, string content)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);

        titleLabel.Text = title;
        contentLabel.Text = content;
    }
}
