using Microsoft.Extensions.Options;
using MyPublicShopifyApp.Settings;
using ShopifySharp;

namespace MyPublicShopifyApp.Services
{
    public class ShopifyUrlBuilder(IOptionsMonitor<ShopifySettings> settings) : IShopifyUrlBuilder
    {
        readonly IOptionsMonitor<ShopifySettings> _settings = settings;

        public string BuildAuthUrl(string shopName, string state)
        {
            var config = _settings.CurrentValue;
            var redirectUri = config.RedirectUri;

            return AuthorizationService.BuildAuthorizationUrl(
                    config.Scopes.Split(','),
                    shopName,
                    config.ClientId,
                    config.RedirectUri
            ).ToString();
        }
    }
}
