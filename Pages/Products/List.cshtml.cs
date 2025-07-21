using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopifySharp;
using ShopifySharp.Filters;

namespace MyPublicShopifyApp.Pages.Products
{
    public class ListModel : PageModel
    {
        public List<Product> Products { get; set; } = [];
        public async Task OnGet()
        {
            Request.Cookies.TryGetValue("tokencookie", out var token);
            var service = new ProductService("previous-stare.myshopify.com", token);
            var apiResult =  await service.ListAsync(new ProductListFilter { Limit = 10 });
            Products = [.. apiResult.Items]; 
        }
    }
}
