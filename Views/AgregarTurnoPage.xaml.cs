using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class AgregarTurnoPage : ContentPage
{
    public AgregarTurnoPage(AgregarTurnoViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
