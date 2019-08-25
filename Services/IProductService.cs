using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.Services.Messages;

namespace aspnet_core_mvc_kojs_demo_crud.Services
{
    public interface IProductService
    {
         Task<DoGetProductsResponse> DoGetProducts(DoGetProductsRequest request = null);
    }
}