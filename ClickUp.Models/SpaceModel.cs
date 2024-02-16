
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
        public string id { get; set; } = null!;
        public string name { get; set; } = null!;
        public string? color { get; set; }
        public bool Private { get; set; }
        public string? avatar { get; set; }
        public bool admin_can_manage { get; set; }
        public List<StatusModel> statuses { get; set; } = new();

        public List<Member> members { get; set; } = new();

    }

}
