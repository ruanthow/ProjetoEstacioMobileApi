using System;

namespace ProjetoEstacio.Model
{
    public class Order
    {
        private Guid Id { get; set; }
        private DateTime Date { get; set; }
        private Guid UserId { get; set; }
        private float Total { get; set; }

       public Order(DateTime date, Guid userId, float total)
        {
            this.Id = Guid.NewGuid();
            this.Date = date;
            this.UserId = userId;
            this.Total = total;
        }
    }
}