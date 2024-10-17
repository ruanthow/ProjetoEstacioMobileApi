using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;
using ProjetoEstacio.Repository;

namespace ProjetoEstacio.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTOResponse>> GetAllProductsAsync()
        {
             var products = await _productRepository.GetAllProducts();
            if (products == null || products.Count < 1)
            {
                return null;
            }
            
          
            return products.Select(product => new ProductDTOResponse()
            {   
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Description = product.Description,
            }).ToList();
        }
    }
}