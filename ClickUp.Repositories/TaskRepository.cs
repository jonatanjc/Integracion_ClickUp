using ClickUp.Repositories.DbContext;
using MongoDB.Driver;

namespace ClickUp.Repositories
{
    public class TaskRepository
    {
        private readonly MongoDbContext context;
        public TaskRepository(MongoDbContext context)
        {
            this.context = context;
        }

    }
}

