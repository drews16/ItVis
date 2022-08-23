using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [Column("ProductType_Id")]
        public int ProductTypeId { get; set; }
        public string BrandName { get; set; } = null!;
        public IEnumerable<ProductType>? ProductType { get; set; }
    }
}
