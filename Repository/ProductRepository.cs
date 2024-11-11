using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEstacio.DbApllication;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDTOResponse>> GetAllProducts()
        { 
            try
            {
                var images = await _context.Images.FromSqlRaw("SELECT * FROM images").ToListAsync();
                var products = await _context.Products.FromSqlRaw("SELECT * FROM products").ToListAsync();

                var response = products.Select(product => new ProductDTOResponse()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    Price = product.Price,
                    Images = images.Where(x => x.ProductId == product.Id).ToList()
                }).ToList();

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Algo deu errado");
            }
        }

        public async Task<Product> GetProductById(Guid id)
        {
            try
            {
                var findProduct = await _context.Products.FindAsync(id);
                if (findProduct != null)
                {
                    return findProduct;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task SaveProduct(ProductDTO productDTO)
        {
            try
            {
                var product = new Product(Guid.NewGuid(), productDTO.Name, productDTO.Description, productDTO.Price, productDTO.Stock);
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task EditProduct(ProductDTO productDTO)
        {
            try
            {
                var productExist = await _context.Products.FindAsync(productDTO.Id);
                if (productExist != null)
                {
                    var product = new Product(productDTO.Id, productDTO.Name, productDTO.Description, productDTO.Price, productDTO.Stock);
                    _context.Attach(product);
                    _context.Entry(product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }

        public async Task DeleteProduct(Guid productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product != null)
                {
                   _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Operação deu errado. tente mais tarde.");
            }
        }
    }
}