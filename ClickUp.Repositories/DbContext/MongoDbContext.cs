using ClickUp.Models;
using ClickUp.Moldels;
using MongoDB.Driver;

namespace ClickUp.Repositories.DbContext
{
    public class MongoDbContext
    {
        public readonly IMongoCollection<FolderModel> FoldersCollection;
        public readonly IMongoCollection<ListModel> ListCollection;
        public readonly IMongoCollection<TaskModel> TaskCollection;
        public readonly IMongoCollection<SpaceModel> SpaceCollection;

        public MongoDbContext(IMongoSetting setting)
        {
            var client = new MongoClient(setting.MongoDBConnection);
            var database = client.GetDatabase(setting.Database);

            FoldersCollection = database.GetCollection<FolderModel>("Folders");
            ListCollection = database.GetCollection<ListModel>("List");
            TaskCollection = database.GetCollection<TaskModel>("Task");
            SpaceCollection = database.GetCollection<SpaceModel>("Spaces");
        }
    }
}
