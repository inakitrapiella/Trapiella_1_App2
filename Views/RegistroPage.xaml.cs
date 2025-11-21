using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage(RegistroViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
