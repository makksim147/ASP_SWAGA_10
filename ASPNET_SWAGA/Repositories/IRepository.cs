namespace ASPNET_SWAGA.Repositories;

public interface IRepository<T> where T : class
{

    Task<List<T>> GetPageAsync(int page, int pageSize, CancellationToken ct = default);

    Task<int> CountAsync(CancellationToken ct = default);

 
    Task<T?> GetByIdAsync(int id, CancellationToken ct = default);


    Task<T?> GetByIdWithDetailsAsync(int id, CancellationToken ct = default);

    Task<bool> ExistsAsync(int id, CancellationToken ct = default);

    Task AddAsync(T entity, CancellationToken ct = default);

    void Update(T entity);

    void Remove(T entity);


    int GetKey(T entity);

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
