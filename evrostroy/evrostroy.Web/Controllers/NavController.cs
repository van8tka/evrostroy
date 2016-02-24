using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Controllers
{
    public class NavController : Controller
    {
       private DataManager datamanager;
        public NavController(DataManager datamanager)
        {
            this.datamanager = datamanager;
        }
        //метод получения всех пунктов меню
        public PartialViewResult Menu()
        {
            string OutDoor = "Входные двери";
            string InDoor = "Межкомнатные двери";
            NavModel model = new NavModel();
            try
            {
                List<string> zetn = new List<string>();
                //получаем список скидки, новинки, уценка
                IEnumerable<string> atten = datamanager.ProductsRepository.GetAllProducts().Select(x => x.Метка).Distinct().OrderBy(x => x);
                if (atten.First() != null || atten.Last() != null)
                {//проходим по подкатегориям
                    foreach (var n in atten)
                    {
                        if (n != null && n != "постоянный")
                        {
                            zetn.Add(n.ToUpper());
                        }
                    }
                }
                model.Attention = zetn;

                

                //входные двери
                List<string> temp = new List<string>();
                IEnumerable<string> brand = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Select(x => x.Производитель).Distinct().OrderBy(x => x);
                foreach(var i in brand)
                {
                    temp.Add(i);
                }
                model.BrandOutDoor = temp;
                IEnumerable<string> country = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Select(x => x.СтранаПроизводитель).Distinct().OrderBy(x => x);
                List<string> temp2 = new List<string>();
                foreach(var i in country)
                {
                    temp2.Add(i);
                }
                model.CountryOutDoor = temp2;
                //межкомнатные двери
                List<string> temp4 = new List<string>();
                IEnumerable<string> brand1 = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Select(x => x.Производитель).Distinct().OrderBy(x => x);
                foreach (var i in brand1)
                {
                    temp4.Add(i);
                }
                model.BrandInDoor = temp4;
                IEnumerable<string> country1 = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Select(x => x.СтранаПроизводитель).Distinct().OrderBy(x => x);
                List<string> temp3 = new List<string>();
                foreach (var i in country1)
                {
                    temp3.Add(i);
                }
                model.CountryInDoor = temp3;
                IEnumerable<string> material = datamanager.ProductsRepository.GetMainCharByCateg("Межкомнатные двери").Select(x => x.Материал).Distinct().OrderBy(x => x);
                List<string> t5 = new List<string>();
                foreach (var i in material)
                {
                    if(i!=null)
                     t5.Add(i);
                }
                model.MaterialInDoor = t5;
                IEnumerable<string> color = datamanager.ProductsRepository.GetMainCharByCateg("Межкомнатные двери").Select(x => x.Цвет).Distinct().OrderBy(x => x);
                List<string> t6 = new List<string>();
                foreach (var i in color)
                {
                    if(i!=null)
                    t6.Add(i);
                }
                model.ColorInDoor = t6;

                Dictionary<string, string> ferstD = new Dictionary<string, string>();
                Dictionary<string, string> secondD = new Dictionary<string, string>();
                //список категорий без дверей
                List<string> temcat =new List<string>(); 
                IEnumerable<string> cat = datamanager.ProductsRepository.GetAllProducts().Select(x => x.Категория).Distinct().OrderBy(x => x);
                foreach(var i in cat)
                {
                   if(i!=OutDoor && i!=InDoor)
                    {
                        IEnumerable<string> cf = datamanager.ProductsRepository.GetAllProducts().Where(z => z.Категория == i).Select(x => x.Подкатегория1).Distinct().OrderBy(x => x);
                        //проверяем на неравенство нулю и существование элементов 
                        if (cf.First() != null || cf.Last() != null)
                        {//проходим по подкатегориям
                            temcat.Add(i);
                            foreach (string j in cf)
                            {//добавляем их в общий список и сохраняем индекс подкатегории
                                ferstD.Add(j, i);
                                IEnumerable<string> cs = datamanager.ProductsRepository.GetAllProducts().Where(z => z.Подкатегория1 == j).Select(x => x.Подкатегория2).Distinct().OrderBy(x => x);
                                if (cs.First() != null || cs.Last() != null)
                                {
                                    foreach(var k in cs)
                                    {
                                        secondD.Add(k, j);
                                    }
                                }
                            }
                        }
                    }
                }
               model.CategoryD = ferstD;
                model.PodCategoryD = secondD;

                model.Category = temcat;
              
                return PartialView(model);
            }
            catch (Exception er)
            {
                LogImplemetation.ClassLog.Write("Ошибка при создании бокового меню NavController/Menu: " + er);
                return PartialView();
            }
       }

        private void RepeatWithoutAddWords(IEnumerable<string> cs, List<string> tem, List<int> index, int podcat2, string ItemRoute, List<string> route)
        {
            if (cs.First() != null || cs.Last() != null)
            {
                //проходим по списку

                foreach (string item in cs)
                {
                    string temp = ItemRoute;
                    if (item != null)
                    {
                        tem.Add(item);
                        index.Add(podcat2);
                        ItemRoute += "/" + item;
                        route.Add(ItemRoute);
                    }
                    ItemRoute = temp;
                }
            }
        }

        public void Repet(IEnumerable<string> ienum,List<string> tem, List<int> id,int ind1,int ind2,string word, string ItemRoute, List<string> route)
        {
            if (ienum.First() != null || ienum.Last() != null)
            {
                tem.Add(word);
                id.Add(ind1);
                ItemRoute += "/" + word;
                route.Add(ItemRoute);
               
                foreach (var a in ienum)
                {
                    string temp = ItemRoute;
                    if (a != null)
                    {
                        tem.Add(a);
                        id.Add(ind2);
                        ItemRoute += "/" + a;
                        route.Add(ItemRoute);
                    }
                    ItemRoute = temp;
                }
               
            }
        }

    
    }
}