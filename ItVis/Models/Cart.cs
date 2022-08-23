using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    [Table("UserCart")]
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<Product>? UserCart { get; set; }
    }
}
