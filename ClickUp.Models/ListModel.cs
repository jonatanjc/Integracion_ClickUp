using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClickUp.Moldels;

namespace ClickUp.Models
{
    public class ListModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public long orderindex { get; set; }

        public string content { get; set; }

        public object status { get; set; }

        public object priority { get; set; }

        [JsonProperty("assignee")]
        public object assignee { get; set; }

        [JsonProperty("task_count")]
        public long task_count { get; set; }

        [JsonProperty("due_date")]
        public string due_date { get; set; }

        [JsonProperty("start_date")]
        public string start_date { get; set; }
        public FolderModel folder { get; set; }

        public SpaceModel space { get; set; }

        public bool archived { get; set; }

        public bool override_statuses { get; set; }

        public string permission_level { get; set; }
    }
}
