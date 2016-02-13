using evrostroy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrostroy.Domain.Implementations
{
    public class EfProductsRepository : IProductsRepository
    {
      private evrostroydbEntities context;

        public EfProductsRepository(evrostroydbEntities context)
        {
            this.context = context;
        }
        public IEnumerable<Товары> GetAllProducts()
        {
            return context.Товары;
        }

        public Товары GetProductByID(int id)
        {
            return context.Товары.Where(x => x.ИдТовара == id).FirstOrDefault();
        }

        public Товары GetProductByName(string name)
        {
            return context.Товары.Where(x => x.Название == name).FirstOrDefault();
        }
    }
}
