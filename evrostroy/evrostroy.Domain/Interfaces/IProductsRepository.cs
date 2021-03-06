﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrostroy.Domain.Interfaces
{
   public interface IProductsRepository
    {
        IEnumerable<Товары> GetAllProducts();
        IEnumerable<ОснХарактеристики> GetAllMainChar();
        Товары GetProductByName(string name);
        Товары GetProductByID(int id);
        ОснХарактеристики GetMainCharById(int id);
        void CreateNewTovar(Товары tov, ОснХарактеристики OsHar, IEnumerable<ДопХарактеристики> DopHar);
        IEnumerable<ОснХарактеристики> GetMainCharByCateg(string category);
    }
}
