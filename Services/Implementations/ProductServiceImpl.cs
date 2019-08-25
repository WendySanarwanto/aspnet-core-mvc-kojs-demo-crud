using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.Models;
using aspnet_core_mvc_kojs_demo_crud.Repositories;
using aspnet_core_mvc_kojs_demo_crud.Services.Messages;

namespace aspnet_core_mvc_kojs_demo_crud.Services.Implementations
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductServiceImpl(IProductRepository productRepo) {
            _productRepo = productRepo;
        }

        public Task<DoGetProductsResponse> DoGetProducts(DoGetProductsRequest request = null)
        {
            // TODO: Get paging & filter info from request, and apply them as filter's params. 
            return Task.Run(()=>{
                DoGetProductsResponse response = new DoGetProductsResponse();

                IEnumerable<ProductModel> products =_productRepo.FindAll();
                if ( (products != null) && (products.Count() > 0)) {
                    response.IsSuccess = true;
                    response.Message = "Success!";
                    response.Products = products;
                } else {
                    response.Message = "Products are not available.";
                    response.Products = new ProductModel[0];
                }

                return response;
            });
        }
    }
}