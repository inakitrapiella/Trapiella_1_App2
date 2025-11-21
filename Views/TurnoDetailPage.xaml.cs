using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class TurnoDetailPage : ContentPage
{
	public TurnoDetailPage(TurnoDetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}