using ImagesTask.Core.Entities;

namespace ImagesTask.Core.Interfaces
{
    public interface ISqlRepository : IRepository<Image>
    {
        IQueryable<Image> Query { get; }

        Task Add(Image entity);
        Task Delete(Image entity);
        Task<List<Image>> GetAll();
        Task SaveChangesAsync();
    }
}