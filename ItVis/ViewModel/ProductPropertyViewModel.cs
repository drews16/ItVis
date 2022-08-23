using ItVis.Models;

namespace ItVis.ViewModel
{
    public class ProductPropertyViewModel
    {
        public Product CurrentProduct { get; set; } = null!;
        public IEnumerable<ProductType> ProductTypes { get; set; } = null!;
        public IEnumerable<ReviewViewModel>? Reviews { get; set; }
        public IEnumerable<ProductProperty> ProductProperties { get; set; } = null!;
    }
}
