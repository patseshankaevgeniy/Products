using Microsoft.Extensions.DependencyInjection;
using ProductsWPF.Views;
using System;

namespace ProductsWPF.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateToAddProductView()
        {
            var addProductWindow = _serviceProvider.GetRequiredService<AddProductWindow>();
            addProductWindow.Show();
        }
    }
}
