using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClickUp.Moldels;
using ClickUp.Models.DTO;

namespace ClickUp.Models
{
    public class ListModel
    {
        public string id { get; set; }

        public string name { get; set; }

        public long orderindex { get; set; }

        public string content { get; set; }

        public StatusDTO? status { get; set; }

        public object priority { get; set; }

        public object assignee { get; set; }

        public long task_count { get; set; }

        public string due_date { get; set; }

        public string start_date { get; set; }
        public FolderDto folder { get; set; }

        public SpaceDto space { get; set; }

        public bool archived { get; set; }

        public bool override_statuses { get; set; }

        public string permission_level { get; set; }
    }
}
