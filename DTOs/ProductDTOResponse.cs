using System;
using System.Collections.Generic;
using ProjetoEstacio.Model;

namespace ProjetoEstacio.DTOs
{
    public class ProductDTOResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public int Stock { get; set; }
        
        public List<Image> Images { get; set; }
    }
}