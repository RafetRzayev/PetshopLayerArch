using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Petshop.DAL.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.DAL.Repositories.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
