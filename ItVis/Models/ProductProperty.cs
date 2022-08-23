using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    [Keyless]
    [Table("vProductProperties")]
    public class ProductProperty
    {
        public int ProductId { get; set; }
        public string Value { get; set; } = null!;
        public string PropertyName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string? EngUnit { get; set; }
    }
}
