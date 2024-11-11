using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEstacio.Model
{
    [Table("products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public int Stock { get; set; }
        
        public Product(Guid id, string name, string description, decimal price, int stock)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price =  Math.Round(price, 2);
            this.Stock = stock;
        }
    }
}