using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.DTO;
using aspnet_core_mvc_kojs_demo_crud.Models;
using aspnet_core_mvc_kojs_demo_crud.Services;
using aspnet_core_mvc_kojs_demo_crud.Services.Messages;
using aspnet_core_mvc_kojs_demo_crud.ViewModels;

namespace aspnet_core_mvc_kojs_demo_crud.Controllers 
{
    public class ProductsController : Controller {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) {
            _productService = productService;
        }

        public async Task<IActionResult> Index() {
            return await Task.Run(() => {
                var delayedResponse = _productService.DoGetProducts();
                delayedResponse.Wait();
                DoGetProductsResponse doGetProductsResponse = delayedResponse.Result;
                IEnumerable<ProductModel> products = doGetProductsResponse.Products;
                
                var productsListViewModel = 
                    doGetProductsResponse.IsSuccess ? 
                        new ProductsListViewModel( products ) : 
                        new ProductsListViewModel( doGetProductsResponse.Message );
                return View(productsListViewModel);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] ProductsDTO request) {
            var doSaveResponse = await _productService.DoSave(new DoSaveRequest { ProductsDTO = request });
            return doSaveResponse.IsSuccess ? 
                    new ObjectResult(doSaveResponse.UpdatedProducts) :
                    new  ObjectResult(new { Message = doSaveResponse.Message });
        }
    }
}