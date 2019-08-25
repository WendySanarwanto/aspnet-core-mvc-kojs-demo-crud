using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.DTO;
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

        public Task<DoSaveResponse> DoSave(DoSaveRequest request)
        {
            return Task.Run(async () => {
                DoSaveResponse response = new DoSaveResponse();

                // TODO: Implement actual DoSave logic at here
                if ( (request.ProductsDTO != null) && 
                     (request.ProductsDTO.Products != null) &&
                     (request.ProductsDTO.Products.Count() > 0) ){
                    var productDtos = request.ProductsDTO.Products;
                    var newProducts = productDtos.Where(pdto => pdto.Id < 0).Select(pdto => pdto.ToModel());
                    int[] deletedProductIds = productDtos.Where(pdto => pdto._destroy).Select(pdto => pdto.Id).ToArray();
                    var updatedProducts = productDtos.Where(pdto => pdto.IsDirty).Select(pdto => pdto.ToModel());

                    var bulkSaveResponse = await _productRepo.BulkSave(newProducts, deletedProductIds, updatedProducts);

                    // Item2 => string, determine error or success
                    if (string.IsNullOrEmpty(bulkSaveResponse.Item2)) {
                        response.IsSuccess = true;
                        int number = 0;
                        // Item1 => ProductModels collection
                        response.UpdatedProducts = new ProductsDTO(bulkSaveResponse.Item1.Select(item => {
                            number++;
                            return new ProductDTO {
                                Number = number,
                                Id = item.Id,
                                Name = item.Name,
                                Price = item.Price,
                                Quantity = item.Quantity,
                                IsDirty = false,
                                _destroy = false
                            };
                        }));
                    } else {
                        response.Message = bulkSaveResponse.Item2;
                    }                    
                } else {
                    response.Message = "Bad request. Product DTOs are either null or empty";
                    response.UpdatedProducts = new ProductsDTO (new ProductDTO [0] );
                }

                return response;
            });
            throw new System.NotImplementedException();
        }
    }
}