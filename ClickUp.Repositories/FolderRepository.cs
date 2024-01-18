using ClickUp.Repositories.DbContext;
using MongoDB.Driver;
using ClickUp.Models;
using ClickUp.Moldels;
using System.Xml.Linq;

namespace ClickUp.Repositories
{
    public class FolderRepository
    {
        private readonly MongoDbContext _mongoContext;

        public FolderRepository(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public List<FolderModel> SaveList(List<FolderModel> list)
        {
            _mongoContext.FoldersCollection.InsertMany(list);
            return list;
        }

        public FolderModel GetById(string id)
        {
            return _mongoContext.FoldersCollection.Find(x => x.id == id).FirstOrDefault();
        }


        public List<FolderModel> GetAllByIds(List<string> listIds)
        {
            return _mongoContext.FoldersCollection.Find(X => listIds.Contains(X.id)).ToList();
        }

        public void Added(FolderModel folder)
        {
            _mongoContext.FoldersCollection.InsertOne(folder);
        }

        public void Update(FolderModel folder)
        {
            var filter = Builders<FolderModel>.Filter.Eq(x => x.id, folder.id);
            var result = _mongoContext.FoldersCollection.Find(filter).FirstOrDefault();
            result.space = folder.space;
            result.statuses = folder.statuses;
            _mongoContext.FoldersCollection.ReplaceOne(filter, result);
        }
    }
}