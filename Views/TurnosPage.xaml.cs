using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;
public partial class TurnoPage : ContentPage
{

	public TurnoPage(TurnosViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}