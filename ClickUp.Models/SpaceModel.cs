
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ClickUp.Models
{

    public class SpaceModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string id { get; set; } = null!;
        [JsonProperty("name")]
        public string name { get; set; } = null!;
        [JsonProperty("color")]
        public string? color { get; set; }
        [JsonProperty("private")]
        public bool Private { get; set; }
        [JsonProperty("avatar")]
        public string? avatar { get; set; }
        [JsonProperty("admin_can_manage")]
        public bool admin_can_manage { get; set; }
        public List<StatusModel> statuses { get; set; } = new();

        public List<Member> members { get; set; } = new();

    }

}
