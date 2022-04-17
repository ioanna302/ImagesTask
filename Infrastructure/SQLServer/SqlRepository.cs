using ImagesTask.Core.Entities;
using ImagesTask.Core.Interfaces;

namespace ImagesTask.Infrastructure.SQLServer
{
    public class SqlRepository : ISqlRepository
    {
        readonly ImagesTaskContext _db;
        public SqlRepository(ImagesTaskContext db)
        {
            _db = db;
            _db.SaveChanges();
        }

        public IQueryable<Image> Query
        {
            get { return _db.Image.AsQueryable(); }
        }

        public async Task<List<Image>> GetAll()
        {
            return Query.ToList();
        }

        public async Task Add(Image entity)
        {
            await _db.Image.AddAsync(entity);
        }

        public async Task Delete(Image entity)
        {
           _db.Image.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
