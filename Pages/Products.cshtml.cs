using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyRazorApp.Models;
using System.Collections.Immutable;

namespace MyRazorApp.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly List<Product> _products = new();
        public ImmutableList<Product> Products = new List<Product>().ToImmutableList();
        public ProductsModel() {
            for (int i = 1; i < 37; i++)
            {
                _products!.Add(
                    new(i, $"Item {i}", i * 10)
                    );
            }
        }

        public void OnGet([FromQuery] int page = 1)
        {
            var take = 5;
            var skip = page == 1 ? 0 : (take * page) - take;

            Products = _products
                .Skip(skip)
                .Take(take)
                .ToImmutableList();
        }
    }
}
