using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace StickerShop.Models
{
    [BsonIgnoreExtraElements]
    public class Sticker
    {
        [BsonId]
        public int StickerId { get; set; }
        [BsonElement("name")]
        public string StickerName { get; set; } = string.Empty;
        [BsonElement("price")]
        public float StickerPrice { get; set; }
        [BsonElement("thumbnail")]
        public string StickerThumbnail { get; set; } = string.Empty;

        [BsonElement("width")]
        public int StickerSizeWidth { get; set; }
        [BsonElement("height")]
        public int StickerSizeHeight { get; set; }
        [BsonElement("categories")]
        public string StickerCategories { get; set; } = string.Empty;
        [BsonElement("colors")]
        public List<string> StickerColors { get; set; } = new List<string>();
        [BsonElement("materials")]
        public List<string> StickerMaterials { get; set; } = new List<string>();
        [BsonElement("description")]
        public string StickerDescription{ get; set; } = string.Empty;
        [BsonElement("imagelink")]
        public string StickerimageLink { get; set; } = string.Empty;
    }
}
