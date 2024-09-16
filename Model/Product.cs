using System;
using System.Collections.Generic;

namespace ProjetoEstacio.Model
{
    public class Product
    {
        private Guid Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private float Price { get; set; }
        private int QuantityStock { get; set; }
        
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