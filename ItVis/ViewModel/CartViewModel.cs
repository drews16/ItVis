using ItVis.Models;

namespace ItVis.ViewModel
{
    public class CartViewModel
    {
        public decimal SumOrder { get; set; }
        public IEnumerable<Product> CartProducts { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; } = null!;
    }
}
