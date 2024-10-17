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
        Task<Product> GetProductById(String productId);
        void SaveProduct( ProductDTOResponse productDtoResponse );
        void EditProduct(Product product);
        void DeleteProduct(Guid productId);
    }
}