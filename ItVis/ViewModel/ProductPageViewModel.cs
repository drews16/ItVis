using ItVis.Models;

namespace ItVis.ViewModel
{
    public class ProductPageViewModel
    {
        public string? CurrentCategory { get; set; }
        public IEnumerable<Product> Products { get; set; } = null!;
        public PagingViewModel PageInfo { get; set; } = null!;
        public IEnumerable<ProductType> ProductTypes { get; set; } = null!;
        public bool IsSearch { get; set; }
        public string? SearchString { get; set; }
        public IEnumerable<Brand> Brands { get; set; } = null!;
    }
}
