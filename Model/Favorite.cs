using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEstacio.Model
{
    [Table("favoritos")]
    public class Favorite
    {
        private Guid id { get; set; }
        private Guid ProductId { get; set; }
        private Guid UserId { get; set; }
        
    }
}