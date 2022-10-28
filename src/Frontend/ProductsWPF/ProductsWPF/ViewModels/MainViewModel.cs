using BusinessLogic.Services;
using ProductsWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ProductsWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IProductsService _productsService;
        private readonly string baseImagesPath = "https://localhost:7159/api/images/";

        public ObservableCollection<ProductModel> Products { get; set; }
        public ProductModel SelectedProduct { get; set; }


        public MainViewModel(IProductsService productsService)
        {
            _productsService = productsService;
            Products = new ObservableCollection<ProductModel>();
        }

        public async Task InitializeAsync()
        {
            var products = await _productsService.GetProductsAsync();
            foreach (var product in products)
            {
                var productModel = new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImageUrl = baseImagesPath + product.Id
                };
                Products.Add(productModel);
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            foreach (var product in Products)
            {
                if (product.Id == id)
                {
                    Products.Remove(product);
                    await _productsService.DeleteProductsAsync(id);
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
