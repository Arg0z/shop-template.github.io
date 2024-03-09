using MongoDB.Bson;
using StickerShop.Models;

namespace StickerShop.Services
{
    public interface iStickerService
    {
        List<Sticker> GetStickers();
        Sticker GetSticker(string Stickerid);
        Sticker CreateSticker(Sticker sticker);
        void UpdateSticker(string Stickerid, Sticker sticker);
        void DeleteSticker(string Stickerid);

    }
}
