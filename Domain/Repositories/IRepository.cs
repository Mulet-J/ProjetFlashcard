namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        int Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T? GetById(string id);
        List<T> GetAll();
    }
}
