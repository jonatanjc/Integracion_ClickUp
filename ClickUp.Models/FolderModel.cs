//using mongodb.bson.serialization.attributes;
//using mongodb.bson;
//using system;
//using system.collections.generic;
//using system.linq;
//using system.text;
//using system.threading.tasks;
//using newtonsoft.json;

//namespace clickup.models
//{
//    public class Foldermodel
//    {
//        [bsonid]
//        [bsonrepresentation(bsontype.objectid)]
//        [jsonproperty("id")]
//        public string id { get; set; } = null!;

//        [jsonproperty("name")]
//        public string name { get; set; } = null!;

//        [jsonproperty("orderindex")]
//        public long orderindex { get; set; }

//        [jsonproperty("override_statuses")]
//        public bool overridestatuses { get; set; }

//        [jsonproperty("hidden")]
//        public bool hidden { get; set; }

//    }
//}
