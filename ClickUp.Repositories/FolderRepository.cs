//using ClickUp.Repositories.DbContext;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MongoDB.Driver;
//using ClickUp.Models;

//namespace ClickUp.Repositories
//{
//    public class FolderRepository
//    {
//        private readonly MongoDbContext _mongoContext;

//        public SpaceRepository(MongoDbContext mongoContext)
//        {
//            _mongoContext = mongoContext;
//        }

//        public List<SpaceModel> SaveList(List<SpaceModel> list)
//        {
//            _mongoContext.SpaceCollection.InsertMany(list);
//            return list;
//        }

//        public SpaceModel GetById(string id)
//        {
//            return _mongoContext.SpaceCollection.Find(x => x.id == id).FirstOrDefault();
//        }

//        public List<SpaceModel> GetByCanManage(bool value)
//        {
//            var builder = Builders<SpaceModel>.Filter;
//            var filter = builder.Empty;

//            filter &= builder.Eq(x => x.admin_can_manage, value);
//            return _mongoContext.SpaceCollection.Find(filter).ToList();
//        }
//    }
//}