using Microsoft.Win32;
using ProductsWPF.ViewModels;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProductsWPF.Views
{
    public partial class AddProductWindow : Window
    {
        private const string FileDialogFilter = "Image Files(*.JPG; *.PNG)|*.JPG; *.PNG | All files (*.*)|*.*";

        private AddProductViewModel _viewModel;

        public AddProductWindow(AddProductViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = viewModel;
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = FileDialogFilter;

            if (fileDialog.ShowDialog() == true)
            {
                var bitMapImage = new BitmapImage(new System.Uri(fileDialog.FileName));
                NewImg.Source = bitMapImage;
                _viewModel.Image = File.ReadAllBytes(fileDialog.FileName);
            }
        }
    }
}
