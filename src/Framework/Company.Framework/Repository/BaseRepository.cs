using Company.Framework.Entity;
using Microsoft.EntityFrameworkCore;

namespace Company.Framework.Repository
{
    public abstract class BaseRepository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity
    {
        private readonly TContext _ctx;
        private readonly DbSet<TEntity> _table;

        public BaseRepository(TContext context)
        {
            _ctx = context;
            _table = _ctx.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _table.ToList();
        }

        public TEntity? GetById(int id)
        {
            return _table.FirstOrDefault(e => e.Id == id);
        }

        public bool Insert(TEntity customer)
        {
            _table.Add(customer);
            int affected = _ctx.SaveChanges();
            return affected > 0;
        }

        public bool Update(TEntity customer)
        {
            _table.Update(customer);
            int affected = _ctx.SaveChanges();
            return affected > 0;
        }

        public bool Delete(TEntity customer)
        {
            _table.Remove(customer);
            int affected = _ctx.SaveChanges();
            return affected > 0;
        }

        public bool DeleteById(int id)
        {
            var employee = _table.Find(id);
            _table.Remove(employee);
            int affected = _ctx.SaveChanges();
            return affected > 0;
        }
    }
}
