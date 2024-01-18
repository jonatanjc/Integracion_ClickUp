using ClickUp.Repositories.DbContext;
using MongoDB.Driver;
using ClickUp.Models;
using ClickUp.Moldels;
using System.Xml.Linq;

namespace ClickUp.Repositories
{
    public class TaskRepository
    {
        private readonly MongoDbContext _mongoContext;

        public TaskRepository(MongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public List<TaskModel> SaveList(List<TaskModel> list)
        {
            _mongoContext.TaskCollection.InsertMany(list);
            return list;
        }

        public TaskModel GetById(string id)
        {
            return _mongoContext.TaskCollection.Find(x => x.id == id).FirstOrDefault();
        }
    }
}
