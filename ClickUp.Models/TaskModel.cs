using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClickUp.Models
{
    public class TaskModel
    {
        public string id;

      
        public object[] tasks { get; set; }

 
        public bool lastPage { get; set; }
    }

}

