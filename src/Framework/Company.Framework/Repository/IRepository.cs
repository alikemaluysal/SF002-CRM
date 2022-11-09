namespace Company.Framework.Repository;

public interface IRepository<TEntity>
    where TEntity : class
{
    public List<TEntity> GetAll();
    public TEntity? GetById(int id);
    public bool Insert(TEntity entity);
    public bool Update(TEntity entity);
    public bool Delete(TEntity entity);
    public bool DeleteById(int id);
}