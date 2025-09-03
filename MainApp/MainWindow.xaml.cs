
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.RightsManagement;
using System.Windows;


namespace MainApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public async Task GetUsersAsync()
    {
        using var client = new HttpClient();
        var response = await client.GetFromJsonAsync<IEnumerable<User>>("https://localhost/api/users");
    }
}