using System;
using System.Collections.Generic;

namespace ProjetoEstacio.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; } 
        public int Stock { get; set; }
        
        public Product(Guid id, string name, string description, float price, int stock)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }
    }
}