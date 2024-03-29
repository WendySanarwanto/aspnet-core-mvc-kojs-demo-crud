using aspnet_core_mvc_kojs_demo_crud.Models;

namespace aspnet_core_mvc_kojs_demo_crud.DTO
{
    public class ProductDTO: ProductModel
    {
        public int Number { set; get;}
        public bool IsDirty { set; get; }
        public bool _destroy { set; get; }

        public ProductModel ToModel() {
            return new ProductModel {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                Quantity = this.Quantity   
            };
        }
    }
}