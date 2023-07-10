using ApisJM.Models;
using ApisJM.Service;
using Newtonsoft.Json;
using SQLite;
using System.Net;

namespace ApisJM.ViewModels;

[QueryProperty("Item", "Item")]
public partial class ConsumoApiDogs : ContentPage
{
    public DogsJM Item
    {
        get => BindingContext as DogsJM;
        set => BindingContext = value;
    }

    public ConsumoApiDogs()
	{
		InitializeComponent();
	}
	public async void Button_Clicked(object sender, EventArgs e)
	{
		string cadena = Buscador.Text;
		var request = new HttpRequestMessage();
		request.RequestUri = new Uri("https://api.thecatapi.com/v1/images/search");
        request.RequestUri = new Uri("https://api.thecatapi.com/v1/images/search?" + cadena);
        request.Method = HttpMethod.Get;
		request.Headers.Add("Accept", "application/json");

		var client = new HttpClient();

		HttpResponseMessage response = await client.SendAsync(request);
		if (response.StatusCode == HttpStatusCode.OK)
		{
			String content = await response.Content.ReadAsStringAsync();
			var resultado = JsonConvert.DeserializeObject<List<ApiDogs>>(content);
			Lista.ItemsSource = resultado;
		}
    }

	private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        if (e.CurrentSelection.FirstOrDefault() is not DogsJM item)
            return;
        Shell.Current.GoToAsync(nameof(DogsItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }

    public class DogsJmDataBase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public DogsJmDataBase(string DatabasePath)
    {
        _dbPath = DatabasePath;
    }
    private void Init()
    {
        if (conn != null)
            return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<DogsJM>();
    }
    public int AddNewDogs(DogsJM dogs)
    {
        Init();
        if (dogs.id != null)
        {
            return conn.Update(dogs);
        }
        else
        {
            return conn.Insert(dogs);
        }
    }
    public List<DogsJM> GetAllDogs()
    {
        Init();
        List<DogsJM> dogs = conn.Table<DogsJM>().ToList();
        return dogs;
    }
    public int DeleteItem(DogsJM item)
    {
        Init();
        return conn.Delete(item);
    }
    }

    private void Agegar(object sender, EventArgs e)
    {
        App.DogsRepo.AddNewDogs(Item);
        Shell.Current.GoToAsync("..");
    }
}
