using System;
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

        public async Task<ProductDTOResponse> GetProductByIdAsync(Guid productId)
        {
            try
            {
                var product = await _productRepository.GetProductById(productId);
                if (product != null)
                {
                    var productDTO = new ProductDTOResponse()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        Stock = product.Stock,
                    };
                    
                    return productDTO;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AddProductAsync(ProductDTO product)
        {
            try
            {
                await _productRepository.SaveProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task UpdateProductAsync(ProductDTO product)
        {
            try
            {
               await _productRepository.EditProduct(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            try
            {
                await _productRepository.DeleteProduct(productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}