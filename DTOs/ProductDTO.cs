using System;

namespace ProjetoEstacio.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; } 
        public int Stock { get; set; }
    }
}