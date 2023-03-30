namespace Lab3.Services
{
    public interface IEntity<T>
    {
        public List<T> GetAllEntities();
        public void AddEntity(T entity);
        public T GetEntityById(int id);
        public void UpdateEntity(T entity);
        public void DeleteEntity(int id);

    }
}
