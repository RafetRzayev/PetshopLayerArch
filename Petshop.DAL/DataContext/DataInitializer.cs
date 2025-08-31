using Microsoft.EntityFrameworkCore;

namespace Petshop.DAL.DataContext;

public class DataInitializer
{
    private readonly AppDbContext _dbContext;

    public DataInitializer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InitializeAsync()
    {
        await _dbContext.Database.MigrateAsync();
    }
}
