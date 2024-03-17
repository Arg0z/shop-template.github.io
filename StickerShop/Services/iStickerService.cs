using MongoDB.Bson;
using StickerShop.Models;

namespace StickerShop.Services
{
    public interface iStickerService
    {
        List<Sticker> GetStickers();
        Sticker GetSticker(int Stickerid);
        Sticker CreateSticker(Sticker sticker);
        void UpdateSticker(int Stickerid, Sticker sticker);
        void DeleteSticker(int Stickerid);
        List<Sticker> GetNewStickers();
        List<Sticker> GetDiscountStickers();
        List<Sticker> GetCategoryStickers(string category);
        List<Sticker> GetColorStickers(string color);
    }
}
