using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Petshop.BLL.Services.Contracts;
using Petshop.BLL.ViewModels;
using Petshop.DAL.DataContext.Entities;
using Petshop.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Petshop.BLL.Services;

public class ProductManager : CrudManager<Product, ProductViewModel, CreateProductViewModel, UpdateProductViewModel>, IProductService
{
    public ProductManager(IRepository<Product> respository, IMapper mapper) : base(respository, mapper)
    {
    }
}
