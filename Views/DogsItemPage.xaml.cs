using ApisJM.Models;
using ApisJM.Data;
namespace ApisJM;

[QueryProperty("Item", "Item")]
public partial class DogsItemPage : ContentPage
{
    public DogsJM Item
    {
        get => BindingContext as DogsJM;
        set => BindingContext = value;
    }
    public DogsItemPage()
	{
		InitializeComponent();
	}
    private void OnSaveClicked(object sender, EventArgs e)
    {
        App.DogsRepo.AddNewDogs(Item);
        Shell.Current.GoToAsync("..");
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.id == null)
            return;
        App.DogsRepo.DeleteItem(Item);
        Shell.Current.GoToAsync("..");
    }
}