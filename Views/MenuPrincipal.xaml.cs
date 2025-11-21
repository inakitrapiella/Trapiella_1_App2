using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class MenuPrincipal : ContentPage
{
	public MenuPrincipal(MenuPrincipalViewModels viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}