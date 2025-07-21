namespace MyPublicShopifyApp.Settings
{
    public class ShopifySettings
    {
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string RedirectUri { get; set; } = "";
        public string Scopes { get; set; } = "read_products,write_products";
    }
}
