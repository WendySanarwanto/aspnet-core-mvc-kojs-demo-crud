using aspnet_core_mvc_kojs_demo_crud.DTO;

namespace aspnet_core_mvc_kojs_demo_crud.Services.Messages
{
    public class DoSaveResponse : BaseResponse
    {
        public ProductsDTO UpdatedProducts { get; set; }
    }
}