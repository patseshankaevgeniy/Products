using BusinessLogic.Models;
using BusinessLogic.Services;
using GalaSoft.MvvmLight.CommandWpf;
using ProductsWPF.Models;
using ProductsWPF.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ProductsWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IProductsService _productsService;
        private readonly INavigationService _navigationService;

        private readonly string baseImagesPath = "https://localhost:7159/api/images/";

        public ObservableCollection<ProductModel> Products { get; set; }
        public ProductModel SelectedProduct { get; set; }

        public RelayCommand NavigateToAddProductCommand { get; set; }


        public MainViewModel(IProductsService productsService,
            INavigationService navigationService)
        {
            _productsService = productsService;
            _navigationService = navigationService;
            Products = new ObservableCollection<ProductModel>();
            NavigateToAddProductCommand = new(NavigateToAddProduct);
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
                    ImageUrl = baseImagesPath + product.ImageId
                };
                Products.Add(productModel);
            }
        }

        public void NavigateToAddProduct()
        {
            _navigationService.NavigateToAddProductView();
        }

        public async Task UpdateAsync()
        {
            //var product = new ProductDto
            //{
            //    Name = SelectedProduct.Name,
            //    ImageId = SelectedProduct.ImageUrl
            //};

            //await _productsService.CreateProductAsync(product);
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
