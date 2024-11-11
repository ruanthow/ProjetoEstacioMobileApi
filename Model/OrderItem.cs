using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEstacio.Model
{
    [Table("orders")]
    public class OrderItem
    {
        private Guid Id { get; set; }
        private Guid IdProduct { get; set; }
        private int Quantity { get; set; }
        private float Price { get; set; }

        public OrderItem(Guid idProduct, int quantity, float price)
        {
            this.Id = Guid.NewGuid();
            this.IdProduct = idProduct;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}