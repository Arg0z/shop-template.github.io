using StickerShop.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;

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

        public void DeleteSticker(int StickerId)
        {
            _stickers.DeleteOne(sticker => sticker.StickerId == StickerId);
        }

        public Sticker GetSticker(int StickerId)
        {
            return _stickers.Find(sticker => sticker.StickerId == StickerId).FirstOrDefault();
        }

        public List<Sticker> GetStickers()
        {
            return _stickers.Find(sticker => true).ToList();            
        }

        public void UpdateSticker(int StickerId, Sticker sticker)
        {
            _stickers.ReplaceOne(sticker => sticker.StickerId == StickerId, sticker);
        }

        public List<Sticker> GetFilteredStickers(bool newSticker, bool discount, string category, string color)
        {
            var filter = Builders<Sticker>.Filter.Empty;
            filter &= Builders<Sticker>.Filter.Eq("discount", discount);
            filter &= Builders<Sticker>.Filter.Eq("new", newSticker);
            filter &= Builders<Sticker>.Filter.AnyEq(s => s.StickerCategories, category);
            filter &= Builders<Sticker>.Filter.AnyEq(s => s.StickerColors, color);
            return _stickers.Find(filter).ToList();
        }
    }
}
