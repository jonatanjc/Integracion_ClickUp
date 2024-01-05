using ClickUp.Repositories.DbContext;
using System.Collections.Generic;
using MongoDB.Driver;
using ClickUp.Models;


namespace ClickUp.Repositories
{
    public class ListRepository
    {
        private readonly MongoDbContext _mongodbcontext;



        public ListRepository(MongoDbContext mongodbcontext)
        {
            _mongodbcontext = mongodbcontext;
        }
    }
}
