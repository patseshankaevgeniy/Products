using BusinessLogic.Models;
using BusinessLogic.Services;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ProductsWPF.ViewModels
{
    public class AddProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductsService _productsService;

        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool ErrorNameVisible { get; set; }


        public RelayCommand CreateProductCommand { get; set; }

        public AddProductViewModel(IProductsService productsService)
        {
            _productsService = productsService;
            
            CreateProductCommand = new(async() => await CreateProductAsync());
        }
        public async Task CreateProductAsync()
        {
            if (string.IsNullOrEmpty(Name))
            {
                ErrorNameVisible = true;
            }
            await _productsService.CreateProductAsync(Name, Image);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
