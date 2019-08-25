using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using aspnet_core_mvc_kojs_demo_crud.Models;

namespace aspnet_core_mvc_kojs_demo_crud.Repositories
{
    public interface IProductRepository
    {
        // Task<ProductsDTO> DoSave(ProductsDTO request);
        IEnumerable<ProductModel> FindAll();
        Task<Tuple<IEnumerable<ProductModel>, string>> BulkSave(IEnumerable<ProductModel> newProducts, int[] deletedProductIds, IEnumerable<ProductModel> updatedProducts);
    }
}