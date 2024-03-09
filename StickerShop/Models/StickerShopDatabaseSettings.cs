namespace StickerShop.Models
{
    public class StickerShopDatabaseSettings : iStickerShopDatabaseSettings
    {
        public string StickerShopCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
