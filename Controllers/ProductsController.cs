using Microsoft.AspNetCore.Mvc;

using aspnet_core_mvc_kojs_demo_crud.Repositories;
using aspnet_core_mvc_kojs_demo_crud.ViewModels;

namespace aspnet_core_mvc_kojs_demo_crud.Controllers 
{
    public class ProductsController : Controller {
        public IActionResult Index() {
            var productsRepo = new ProductRepository();
            var productsListViewModel = new ProductsListViewModel(
                productsRepo.FindAll()
            );
            return View(productsListViewModel);
        }
    }
}