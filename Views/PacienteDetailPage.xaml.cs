using AppParcialesMauiTrapiella.Services;
using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class PacienteDetailPage : ContentPage
{
	public PacienteDetailPage()
	{
		InitializeComponent();
		var api = new ApiService(new HttpClient());
        BindingContext = new PacienteDetailViewModel(api);
	}
}