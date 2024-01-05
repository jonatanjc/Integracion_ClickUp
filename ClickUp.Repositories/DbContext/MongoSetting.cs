using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickUp.Repositories.DbContext
{
    public class MongoSetting : IMongoSetting
    {
        public string MongoDBConnection { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password
        {
            get; set;
        }
    }

    public interface IMongoSetting
    {
        string MongoDBConnection { get; set; }
        string Database { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }
}
