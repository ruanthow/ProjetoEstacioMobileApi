using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEstacio.DbApllication;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.FromSqlRaw("SELECT * FROM products").ToListAsync();
        }
    }
}