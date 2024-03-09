using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace StickerShop.Models
{
    [BsonIgnoreExtraElements]
    public class Sticker
    {
        [BsonId]
        [NotNull]
        public string StickerId { get; set; } = string.Empty;
        [BsonElement("name")]
        public string StickerName { get; set; } = string.Empty;
        [BsonElement("width")]
        public int StickerSizeWidth { get; set; }
        [BsonElement("height")]
        public int StickerSizeHeight { get; set; }
        [BsonElement("categories")]
        public string Categories { get; set; } = string.Empty;
        [BsonElement("imagelink")]
        public string imageLink { get; set; } = string.Empty;
    }
}
