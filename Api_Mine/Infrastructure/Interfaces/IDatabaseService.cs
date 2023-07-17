namespace Api_Mine.Infrastructure.Interfaces
{
    public interface IDatabaseService<T> where T : class
    {
        Task<T> Get(int id);
        Task<T> Update(T data);
        Task<T> Delete(int id);
        Task<T> Add(T data);
    }
}
