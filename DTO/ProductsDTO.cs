using System.Collections.Generic;

namespace aspnet_core_mvc_kojs_demo_crud.DTO {
    public class ProductsDTO {
        public ProductsDTO(IEnumerable<ProductDTO> productsDto) {
            Products = productsDto;
        }
        
        public IEnumerable<ProductDTO> Products { set; get; }
    }
}