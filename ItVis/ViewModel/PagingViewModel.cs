using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ItVis.ViewModel
{
    public class PagingViewModel
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public PagingViewModel(int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;     
    }
}
