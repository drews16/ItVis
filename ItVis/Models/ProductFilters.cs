using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    [Keyless]
    [Table("vProductFilters")]
    public class ProductFilters
    {
        [Column("Prop")]
        public string Property { get; set; } = null!;
        [Column("ProdType")]
        public string ProductType { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        [Column("Value")]
        public string? PropertyValue { get; set; }
        public string? EngUnit { get; set; }
        [NotMapped]
        public string? PropValue { get; set; }
    }
}
