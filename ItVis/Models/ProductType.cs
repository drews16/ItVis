using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    public class ProductType
    {
        public int Id { get; private set; }
        public string TypeName { get; set; } = null!;
        public string Img { get; private set; } = null!;
        public IEnumerable<Brand>? Brands { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
