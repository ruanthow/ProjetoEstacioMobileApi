using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEstacio.Model
{
    [Table("images")]
    public class Image
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        
        public Image(Guid productId, string imagePath)
        {
            this.Id = Guid.NewGuid();
            this.ProductId = productId;
            this.ImagePath = imagePath;
        }
    }
}