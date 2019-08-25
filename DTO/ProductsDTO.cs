using System.Collections.Generic;

namespace aspnet_core_mvc_kojs_demo_crud.DTO {
    public class ProductsDTO {
        public IEnumerable<ProductDTO> Products { set; get; }
    }
}