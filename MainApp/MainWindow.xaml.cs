
using MainApp.Models;
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
    //https://localhost/api/users
    public async Task GetUsersAsync() //Hämta data 
    {
        using var client = new HttpClient(); //REST förfrågan
        var data = await client.GetFromJsonAsync<IEnumerable<User>>("https://localhost/api/users"); //Hämtar data från API:et, converterar från json till Ienumarable list
        //var response = await client.GetFromJsonAsync<IEnumerable<User>>("https://localhost/api/users");


        Lv_UserList.ItemsSource = data;
    
    }

    private async void Btn_GetUsers_Click(object sender, RoutedEventArgs e)
    {
        await GetUsersAsync();

    }
}