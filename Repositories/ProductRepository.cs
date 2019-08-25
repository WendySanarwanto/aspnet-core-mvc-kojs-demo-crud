using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.DTO;
using aspnet_core_mvc_kojs_demo_crud.Models;

namespace aspnet_core_mvc_kojs_demo_crud.Repositories {
    public class ProductRepository: IProductRepository {
        public Task<Tuple<IEnumerable<ProductModel>, string>> BulkSave(IEnumerable<ProductModel> newProducts, int[] deletedProductIds, IEnumerable<ProductModel> updatedProducts)
        {
            throw new NotImplementedException();
        }

        // public Task<ProductsDTO> DoSave(ProductsDTO request)
        // {
        //     return Task.Run(() => {
        //         return 
        //     });
        // }

        public IEnumerable<ProductModel> FindAll() {
            // TODO: Get them from datasource
            return new []{
                new ProductModel {
                    Id = 1,
                    Name = "Motherboard AMD ASUS ROG STRIX X570-E Gaming",
                    Price = 460,
                    Quantity = 12
                }, 
                new ProductModel {
                    Id = 2,
                    Name = "Motherboard ASUS - TUF GAMING X570-PLUS",
                    Price = 275,
                    Quantity = 18
                },
                new ProductModel {
                    Id = 3,
                    Name = "VGA ASUS - TUF-RTX2060-6G-GAMING",
                    Price = 415,
                    Quantity = 48
                },
                new ProductModel {
                    Id = 4,
                    Name = "Asus Gaming Monitor VG258Q 24.5' 144Hz G-Sync/FreeSync",
                    Price = 320,
                    Quantity = 12
                },
                new ProductModel {
                    Id = 5,
                    Name = "Asus Gaming Monitor ROG Strix XG258Q 240Hz G-Sync/FreeSync",
                    Price = 450,
                    Quantity = 48
                }                                               
            };
        }
    }
}