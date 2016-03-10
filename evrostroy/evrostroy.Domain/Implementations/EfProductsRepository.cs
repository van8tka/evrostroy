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

        public IEnumerable<ОснХарактеристики> GetMainCharByCateg(string category)
        {
           
            IEnumerable<ОснХарактеристики> ret = from o in context.ОснХарактеристики
                        join t in context.Товары on o.ИдТовара equals t.ИдТовара where(t.Категория == category)
                        select o;

            return ret;
        }

        public IEnumerable<ОснХарактеристики> GetAllMainChar()
        {
            return context.ОснХарактеристики;
        }

        public IEnumerable<Товары> GetAllProducts()
        {
            return context.Товары;
        }

        public ОснХарактеристики GetMainCharById(int id)
        {
            return context.ОснХарактеристики.Where(x => x.ИдТовара == id).FirstOrDefault();
        }

        public Товары GetProductByID(int id)
        {
            return context.Товары.Where(x => x.ИдТовара == id).FirstOrDefault();
        }

        public Товары GetProductByName(string name)
        {
            return context.Товары.Where(x => x.Название == name).FirstOrDefault();
        }

        public void CreateNewTovar(Товары tov, ОснХарактеристики OsHar, IEnumerable<ДопХарактеристики> DopHar)
        {
            if(tov!=null)
            {
                context.Товары.Add(tov);
                context.SaveChanges();
            }
           if(OsHar!=null)
            {
                context.ОснХарактеристики.Add(OsHar);
                context.SaveChanges();
            }
           foreach(var i in DopHar)
            {
                if(i!=null)
                {
                    context.ДопХарактеристики.Add(i);
                }
                context.SaveChanges();
            }

        }
    }
}
