using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModels viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
