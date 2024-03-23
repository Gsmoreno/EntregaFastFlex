namespace FastFlex.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T obj);
        Task Update(T obj);
        Task Delete(T obj);     
        Task<T> GetEntityById(int Id);
        Task<List<T>> GetAll(); 
    }
}
