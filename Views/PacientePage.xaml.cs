using AppParcialesMauiTrapiella.Services;
using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class PacientePage : ContentPage
{
	public PacientePage(PacientesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}