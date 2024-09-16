using System;

namespace ProjetoEstacio.Model
{
    public class Image
    {
        private Guid Id { get; set; }
        private Guid ProductId { get; set; }
        private string ImagePath { get; set; }
        
        public Image(Guid productId, string imagePath)
        {
            this.Id = Guid.NewGuid();
            this.ProductId = productId;
            this.ImagePath = imagePath;
        }
    }
}