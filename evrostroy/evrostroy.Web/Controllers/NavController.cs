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
                IEnumerable<string> cat = datamanager.ProductsRepository.GetAllProducts().Select(x => x.Категория).Distinct().OrderBy(x => x);
                foreach(var i in cat)
                {
                    List<string> podcat1 = new List<string>();
                    if(i!=OutDoor && i!=InDoor)
                    {
                        IEnumerable<string> cf = datamanager.ProductsRepository.GetAllProducts().Where(z => z.Категория == i).Select(x => x.Подкатегория1).Distinct().OrderBy(x => x);
                        //проверяем на неравенство нулю и существование элементов 
                        if (cf.First() != null || cf.Last() != null)
                        {//проходим по подкатегориям
                         
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
              

                //List<string> route = new List<string>();

                //List<string> temp = new List<string>();
                //List<int> index = new List<int>();
                //int category = 0, podcat1 = 1, podcat2 = 2,ibrand = 3, icountry = 4,icolor = 5,imater = 6, idontactiv = 7;
                //string br = "Брэнд";
                //string countr = "Страна изготовитель";
                //string color = "Цвет";
                //string material = "Материал";
                //List<string> zet = new List<string>();
                ////получаем список скидки, новинки, уценка
                //IEnumerable<string> atten = datamanager.ProductsRepository.GetAllProducts().Select(x => x.Метка).Distinct().OrderBy(x => x);
                //if (atten.First() != null || atten.Last() != null)
                //{//проходим по подкатегориям
                //    foreach (var i in atten)
                //    {
                //        if(i!=null && i!="постоянный")
                //        {                          
                //            zet.Add(i.ToUpper());
                //        }
                //    }
                //}
                //model.Attention = zet;
                ////получаем список категорий
                //IEnumerable<string> cat = datamanager.ProductsRepository.GetAllProducts().Select(x => x.Категория).Distinct().OrderBy(x => x);
                ////проходим по категориям
                //foreach (string c in cat)
                //{//добавляем в общий список вывода меню и сохраняем индексы
                //    string ItemRoute = null;
                //    ItemRoute = c;
                //    route.Add(ItemRoute);
                //    temp.Add(c);
                //    index.Add(category);
                //    //получаем по выбранной категории список подкатегорий
                //    IEnumerable<string> cf = datamanager.ProductsRepository.GetAllProducts().Where(z => z.Категория == c).Select(x => x.Подкатегория1).Distinct().OrderBy(x => x);
                //    //проверяем на неравенство нулю и существование элементов 
                //    if (cf.First() != null || cf.Last() != null)
                //    {//проходим по подкатегориям
                //        foreach (string i in cf)
                //        {//добавляем их в общий список и сохраняем индекс подкатегории
                //            string temproute = ItemRoute;
                //            ItemRoute += "/" + i;
                //            route.Add(ItemRoute);
                //            temp.Add(i);
                //            index.Add(podcat1);

                //            if (i=="Ламинат"||i=="Линолеум"||i=="Ковровое покрытие"||i=="Паркетная доска")
                //            {
                //                IEnumerable<string> bran = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория1 == i).Select(x => x.Производитель).Distinct().OrderBy(x => x);
                //                //метод проверки и добавления в общий список
                //               RepeatWithoutAddWords(bran, temp, index, ibrand, ItemRoute,route);
                //             }
                //            //получаем список под категорий 2
                //            IEnumerable<string> cs = datamanager.ProductsRepository.GetAllProducts().Where(z => z.Подкатегория1 == i).Select(x => x.Подкатегория2).Distinct().OrderBy(x => x);
                //            //проверяем на наличие
                //            RepeatWithoutAddWords(cs, temp, index, podcat2, ItemRoute, route);
                //            ItemRoute = temproute;
                //        }
                //        if (c == "Напольные покрытия")
                //        {
                //            //цвет
                //            IEnumerable<string> col = datamanager.ProductsRepository.GetMainCharByCateg(c).Select(x => x.Цвет).Distinct().OrderBy(x => x);
                //            Repet(col, temp, index, idontactiv, icolor, color,ItemRoute,route);
                //        }

                //    }
                //    else
                //    {
                //        //получаем список брэндов категории
                //        IEnumerable<string> bran = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == c).Select(x => x.Производитель).Distinct().OrderBy(x => x);
                //        //метод проверки и добавления в общий список

                //        Repet(bran, temp, index, idontactiv, ibrand, br, ItemRoute, route);

                //        //получаем список стран категории
                //        IEnumerable<string> co = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == c).Select(x => x.СтранаПроизводитель).Distinct().OrderBy(x => x);
                //        Repet(co, temp, index, idontactiv, icountry, countr, ItemRoute, route);

                //        //получаем список материало категории
                //        IEnumerable<string> mat = datamanager.ProductsRepository.GetMainCharByCateg(c).Select(x => x.Материал).Distinct().OrderBy(x => x);
                //        Repet(mat, temp, index, idontactiv, imater, material, ItemRoute, route);

                //        //получаем список цветов категории
                //        IEnumerable<string> col = datamanager.ProductsRepository.GetMainCharByCateg(c).Select(x => x.Цвет).Distinct().OrderBy(x => x);
                //        Repet(col, temp, index, idontactiv, icolor, color, ItemRoute, route);
                //    }                 
                //}
                ////добавили элемент маршрут поиска для передачи в др контроллер
                //model.RoutProduct = route;
                ////сохраняем колличество элементов
                //model.Lenght = index.Count();
                ////сохр весь список элементов
                //model.AllItems = temp;
                ////сохр индексы элементов
                //model.Index = index;
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