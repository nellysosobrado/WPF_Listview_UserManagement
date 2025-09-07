
using MainApp.Models;
using System.Collections.ObjectModel;
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

    private ObservableCollection<User> _users = []; //ObservableCollection är en lista som kan notifiera UI när den ändras
    public MainWindow()
    {
        InitializeComponent();
        //gränsnittet renderas direkt när InitializeComponent körs, och då får man inte error
        Loaded += async(_,_)=> await GetUsersAsync(); //När fönstret är laddat, hämta data
                                                     // Task.Run(GetUsersAsync);
                                                     // Lv_UserList.ItemsSource = _users; //Sätter datakällan för listviewen

        //async void kan inte anropas i konstruktorn
        //async Task kan anropas i konstruktorn men måste köras i en Task.Run då den inte kan vara async
    }
    //https://localhost/api/users
    public async Task GetUsersAsync() //Hämta data 
    {
        using var client = new HttpClient(); //REST förfrågan
        var data = await client.GetFromJsonAsync<ObservableCollection<User>>("https://localhost/api/users"); //Hämtar data från API:et, converterar från json till Ienumarable list
        //var response = await client.GetFromJsonAsync<IEnumerable<User>>("https://localhost/api/users");

        Lv_UserList.ItemsSource = data ?? [];

        //foreach(var user in data!) //Lägger till varje user i ObservableCollection
        //    _users.Add(user);

    }

  
}