using ProductsWPF.ViewModels;
using ProductsWPF.Views;
using System.Windows;

namespace ProductsWPF
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;

        public MainWindow(MainViewModel viewModel)
        {
            _mainViewModel = viewModel;
            InitializeComponent();
            DataContext = viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _mainViewModel.InitializeAsync();
        }


        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EditProductWindow editProductWindow = new EditProductWindow(_mainViewModel);
            editProductWindow.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.DeleteProduct(_mainViewModel.SelectedProduct.Id);
        }
    }
}
