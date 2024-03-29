﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;
using ClickUp.Models;
using ClickUp.Models.DTO;

namespace ClickUp.Moldels
{
    public class FolderModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string id { get; set; } = null!;

        [JsonProperty("name")]
        public string name { get; set; } = null!;

        [JsonProperty("orderindex")]
        public long orderindex { get; set; }

        [JsonProperty("override_statuses")]
        public bool override_statuses { get; set; }

        [JsonProperty("hidden")]
        public bool hidden { get; set; }

        public SpaceDto space { get; set; }

        public string task_count { get; set; }

        public bool archived { get; set; }

        public List<StatusModel> statuses { get; set; } = new();

        public string permission_level { get; set; }

        public List<ListModel> lists { get; set; } = new();


        


    }
}
