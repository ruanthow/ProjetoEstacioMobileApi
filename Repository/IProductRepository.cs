using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid productId);
        Task SaveProduct(ProductDTO productDTO );
        Task EditProduct(ProductDTO product);
        Task DeleteProduct(Guid productId);
    }
}