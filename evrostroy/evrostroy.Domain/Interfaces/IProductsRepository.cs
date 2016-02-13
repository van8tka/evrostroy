using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrostroy.Domain.Interfaces
{
   public interface IProductsRepository
    {
        IEnumerable<Товары> GetAllProducts();
        Товары GetProductByName(string name);
        Товары GetProductByID(int id);
    }
}
