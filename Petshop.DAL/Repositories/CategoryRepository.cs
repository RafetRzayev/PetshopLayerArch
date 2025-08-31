using Petshop.DAL.DataContext;
using Petshop.DAL.DataContext.Entities;
using Petshop.DAL.Repositories.Contracts;

namespace Petshop.DAL.Repositories;

public class CategoryRepository : EfCoreRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    //public override Task CreateAsync(Category entity)
    //{
    //    entity.CreatedAt = DateTime.UtcNow.AddHours(4);

    //    return base.CreateAsync(entity);
    //}

    //override public Task UpdateAsync(Category entity)
    //{
    //    entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
    //    return base.UpdateAsync(entity);
    //}
}