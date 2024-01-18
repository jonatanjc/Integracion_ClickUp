using ClickUp.Models;
using ClickUp.Moldels;
using ClickUp.Repositories.DbContext;
using MongoDB.Driver;


namespace ClickUp.Repositories
{
    public class ListRepository
    {
        private readonly MongoDbContext _mongoContext;

        public ListRepository(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public List<ListModel> SaveMany(List<ListModel> list)
        {
            _mongoContext.ListCollection.InsertMany(list);
            return list;
        }

        public ListModel GetById(string id)
        {
            return _mongoContext.ListCollection.Find(x => x.id == id).FirstOrDefault();
        }
        public List<ListModel> GetAllByIds(List<string> listIds)
        {
            return _mongoContext.ListCollection.Find(x => listIds.Contains(x.id)).ToList();
        }
        public void SaveOne(ListModel list)
        {
            _mongoContext.ListCollection.InsertOne(list);
        }
        public void Update(ListModel list)
        {
            var filter = Builders<ListModel>.Filter.Eq(x => x.id, list.id);
            var result = _mongoContext.ListCollection.Find(filter).FirstOrDefault();
            result.name = list.name;
            result.orderindex = list.orderindex;
            result.content = list.content;
            result.status = list.status;
            result.priority = list.priority;
            result.assignee = list.assignee;
            result.task_count = list.task_count;
            result.due_date = list.due_date;
            result.start_date = list.start_date;

            _mongoContext.ListCollection.ReplaceOne(filter, result);
        }
    }
}

