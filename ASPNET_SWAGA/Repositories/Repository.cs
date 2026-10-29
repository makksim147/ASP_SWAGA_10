using ASPNET_SWAGA.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_SWAGA.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AspNetContext Context;
    protected readonly DbSet<T> Set;
    private readonly string _keyName;

    public Repository(AspNetContext context)
    {
        Context = context;
        Set = context.Set<T>();
        _keyName = context.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!.Properties[0].Name;
    }

    protected virtual IQueryable<T> IncludeDetails(IQueryable<T> query) => query;

    public async Task<List<T>> GetPageAsync(int page, int pageSize, CancellationToken ct = default) =>
        await IncludeDetails(Set.AsNoTracking())
            .OrderBy(e => EF.Property<int>(e, _keyName))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

    public Task<int> CountAsync(CancellationToken ct = default) => Set.CountAsync(ct);

    public Task<T?> GetByIdAsync(int id, CancellationToken ct = default) =>
        Set.Where(e => EF.Property<int>(e, _keyName) == id).FirstOrDefaultAsync(ct);

    public Task<T?> GetByIdWithDetailsAsync(int id, CancellationToken ct = default) =>
        IncludeDetails(Set.AsNoTracking())
            .Where(e => EF.Property<int>(e, _keyName) == id)
            .FirstOrDefaultAsync(ct);

    public Task<bool> ExistsAsync(int id, CancellationToken ct = default) =>
        Set.AnyAsync(e => EF.Property<int>(e, _keyName) == id, ct);

    public async Task AddAsync(T entity, CancellationToken ct = default) => await Set.AddAsync(entity, ct);

    public void Update(T entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached)
            Set.Update(entity);
    }

    public void Remove(T entity) => Set.Remove(entity);

    public int GetKey(T entity) => (int)Context.Entry(entity).Property(_keyName).CurrentValue!;

    public Task<int> SaveChangesAsync(CancellationToken ct = default) => Context.SaveChangesAsync(ct);
}
