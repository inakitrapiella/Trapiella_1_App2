using AppParcialesMauiTrapiella.ViewsModels;

namespace AppParcialesMauiTrapiella
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
