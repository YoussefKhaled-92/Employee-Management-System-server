namespace MyTask.DAL
{
    public interface IRepository<T> where T : DomainObject
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
	    void Update(T entity);
        void Delete(T entity);
	    void Delete(int id);
    }
}
