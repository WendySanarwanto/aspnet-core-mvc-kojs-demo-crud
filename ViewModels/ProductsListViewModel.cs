using System.Collections.Generic;

using aspnet_core_mvc_kojs_demo_crud.Models;

namespace aspnet_core_mvc_kojs_demo_crud.ViewModels {
    public class ProductsListViewModel {
        public ProductsListViewModel(IEnumerable<ProductModel> products) {
            Products = products;
        }

        public IEnumerable<ProductModel> Products { set; get; }
    }
}