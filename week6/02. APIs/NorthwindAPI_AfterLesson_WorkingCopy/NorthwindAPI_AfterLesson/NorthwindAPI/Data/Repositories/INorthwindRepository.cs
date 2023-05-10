namespace NorthwindAPI.Data.Repositories

{


    public interface INorthwindRepository<T> 
    {
        // will use this interface to interact with Entity Framework
        bool IsNull { get; }

        Task<IEnumerable<T>> GetAllAsync(); // You don't need to use the async keyword in an interface, but you will later in a class

        Task<T?> FindAsync(int id);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        Task SaveAsync();

    }

}