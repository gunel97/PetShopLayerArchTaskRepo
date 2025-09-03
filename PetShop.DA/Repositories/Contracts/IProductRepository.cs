using PetShop.DA.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DA.Repositories.Contracts
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
