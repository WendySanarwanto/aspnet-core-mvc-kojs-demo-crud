using System.Collections.Generic;

using aspnet_core_mvc_kojs_demo_crud.Models;

namespace aspnet_core_mvc_kojs_demo_crud.Services.Messages
{
    public class DoGetProductsResponse: BaseResponse
    {
        public IEnumerable<ProductModel> Products { set; get; }
    }
}