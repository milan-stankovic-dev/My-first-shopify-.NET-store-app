namespace MyPublicShopifyApp.Services
{
    public interface IShopifyUrlBuilder
    {
        string BuildAuthUrl(string shopName, string state);
    }
}
