using AppParcialesMauiTrapiella.Services;
using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class PacientePage : ContentPage
{
	public PacientePage()
	{
		InitializeComponent();
        var api = new ApiService(new HttpClient());
        BindingContext = new PacientesViewModel(api);
    }
}