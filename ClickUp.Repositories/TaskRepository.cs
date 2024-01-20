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

        public List<TaskModel> SaveMany(List<TaskModel> list)
        {
            _mongoContext.TaskCollection.InsertMany(list);
            return list;
        }

        public TaskModel GetById(string id)
        {
            return _mongoContext.TaskCollection.Find(x => x.id == id).FirstOrDefault();
        }
        public TaskModel Regist(TaskModel model)
        {
            _mongoContext.TaskCollection.InsertOne(model);
            return model;
        }

        public List<TaskModel> InsertOne(TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}
