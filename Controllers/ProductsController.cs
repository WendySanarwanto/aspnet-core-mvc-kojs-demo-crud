using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.Repositories;
using aspnet_core_mvc_kojs_demo_crud.ViewModels;

namespace aspnet_core_mvc_kojs_demo_crud.Controllers 
{
    public class ProductsController : Controller {
        public async Task<IActionResult> Index() {
            return await Task.Run(() => {
                var productsRepo = new ProductRepository();
                var productsListViewModel = new ProductsListViewModel(
                    productsRepo.FindAll()
                );                
                return View(productsListViewModel);
            });
        }

    }
}