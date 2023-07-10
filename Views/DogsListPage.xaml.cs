using ApisJM.Models;

namespace ApisJM.Views;

public partial class DogsListPage : ContentPage
{
	public DogsListPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    public void OnItemAdded(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DogsItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new DogsJM()
        });
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        List<DogsJM> dogs = App.DogsRepo.GetAllDogs();
        dogsList.ItemsSource = dogs;
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
}