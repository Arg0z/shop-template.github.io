using StickerShop.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StickerShop.Services
{
    public class StickerController : iStickerService
    {
        private readonly IMongoCollection<Sticker> _stickers;

        public StickerController(iStickerShopDatabaseSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _stickers = database.GetCollection<Sticker>(settings.StickerShopCollectionName);
        }
        public Sticker CreateSticker(Sticker sticker)
        {
            _stickers.InsertOne(sticker);
            return sticker;
        }

        public void DeleteSticker(string StickerId)
        {
            _stickers.DeleteOne(sticker => sticker.StickerId == StickerId);
        }

        public Sticker GetSticker(string StickerId)
        {
            return _stickers.Find(sticker => sticker.StickerId == StickerId).FirstOrDefault();
        }

        public List<Sticker> GetStickers()
        {
            return _stickers.Find(sticker => true).ToList();            
        }

        public void UpdateSticker(string StickerId, Sticker sticker)
        {
            _stickers.ReplaceOne(sticker => sticker.StickerId == StickerId, sticker);
        }
    }
}
