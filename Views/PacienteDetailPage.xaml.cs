using AppParcialesMauiTrapiella.Services;
using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class PacienteDetailPage : ContentPage
{
	public PacienteDetailPage(PacienteDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}