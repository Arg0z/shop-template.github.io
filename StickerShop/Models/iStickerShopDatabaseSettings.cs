namespace StickerShop.Models
{
    public interface iStickerShopDatabaseSettings
    {
        string StickerShopCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
