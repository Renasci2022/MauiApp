using System.ComponentModel;

namespace SimpleApp.Models;

public class MainViewModel
{
    public List<Post>? Posts { get; set; }

    private Post? _selectedPost;
    public Post? SelectedPost
    {
        get => _selectedPost;
        set
        {
            if (_selectedPost != value)
            {
                _selectedPost = value;
                OnPropertyChanged(nameof(SelectedPost));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
