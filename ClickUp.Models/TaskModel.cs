using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClickUp.Models; 


namespace ClickUp.Models
{
    public class TaskModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id;

        public string name { get; set; }

        public string description { get; set; }

        public long[] Assignees { get; set; }

        public string[] tags { get; set; }

        public string status { get; set; }

        public long priority { get; set; }

        public long due_date { get; set; }

        public bool due_date_time { get; set; }

        public long time_estimate { get; set; }

        public long start_date { get; set; }

        public bool start_date_time { get; set; }

        public bool notify_all { get; set; }

        public object parent { get; set; }

        public object links_to { get; set; }
    //    public CustomField[] CustomFields { get; set; }
    //}

    //public partial class CustomField
    //{
    //    public Guid Id { get; set; }

    //    public long value { get; set; }
    }





}

