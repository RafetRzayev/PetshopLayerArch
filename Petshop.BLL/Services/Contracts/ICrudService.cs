using Microsoft.EntityFrameworkCore.Query;
using Petshop.DAL.DataContext.Entities;
using System.Linq.Expressions;

namespace Petshop.BLL.Services.Contracts;

public interface ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel>
    where TEntity : Entity
{
    Task<IEnumerable<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool AsNoTracking = false);

    Task<TViewModel?> GetByIdAsync(int id);
    Task CreateAsync(TCreateViewModel model);
    Task<bool> UpdateAsync(int id, TUpdateViewModel model);
    Task<bool> DeleteAsync(int id);
}
