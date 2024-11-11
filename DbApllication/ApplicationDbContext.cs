using Microsoft.EntityFrameworkCore;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.DbApllication
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Image> Images { get; set; }
    }
}