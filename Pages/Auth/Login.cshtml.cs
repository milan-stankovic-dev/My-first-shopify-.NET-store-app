using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPublicShopifyApp.Services;

namespace MyPublicShopifyApp.Pages.Auth
{
    public class LoginModel(IShopifyUrlBuilder urlBuilder) : PageModel
    {
        readonly IShopifyUrlBuilder _urlBuilder = urlBuilder;

        public IActionResult OnGet(string shop = "previous-stare.myshopify.com")
        {
            var state = Guid.NewGuid().ToString();
            var authUrl = _urlBuilder.BuildAuthUrl(shop, state);

            return Redirect(authUrl);
        }
    }
}
