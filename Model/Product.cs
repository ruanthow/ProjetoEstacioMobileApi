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
        public int QuantityStock { get; set; }
        
        public Product(string name, string description, float price, int quantityStock)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.QuantityStock = quantityStock;
        }
    }
}