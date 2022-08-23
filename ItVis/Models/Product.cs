using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    public class Product
    {
        public int Id { get; private set; }
        [Column("ProductType_Id")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;
        [Column("Brand_Id")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public string Img { get; set; } = null!;
        public int? CartId { get; set; }
    }
}
