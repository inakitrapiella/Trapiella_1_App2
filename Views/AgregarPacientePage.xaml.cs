using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views;

public partial class AgregarPacientePage : ContentPage
{
    public AgregarPacientePage(AgregarPacienteViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
