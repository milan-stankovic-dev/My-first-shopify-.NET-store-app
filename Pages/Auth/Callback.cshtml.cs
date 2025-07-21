using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MyPublicShopifyApp.Settings;
using ShopifySharp;

namespace MyPublicShopifyApp.Pages.Auth
{
    public class CallbackModel(IOptionsMonitor<ShopifySettings> options) : PageModel
    {
        readonly ShopifySettings settings = options.CurrentValue;
        public async Task<IActionResult> OnGetAsync(string code, string shop, string state)
        {
            var token = await AuthorizationService
                .Authorize(
                    shop,
                    settings.ClientId,
                    settings.ClientSecret,
                    code);

            Response.Cookies.Append("tokencookie", token ?? "N/A", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

            return RedirectToPage("/Products/List"); 
        }
    }
}
