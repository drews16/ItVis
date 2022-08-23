using ItVis.Models;

namespace ItVis.ViewModel
{
    public class SearchViewModel
    {
        public string SearchString { get; set; } = null!;
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; } = null!;
        public PagingViewModel PageInfo { get; set; } = null!;
    }
}
