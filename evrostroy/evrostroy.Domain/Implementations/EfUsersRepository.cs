using evrostroy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrostroy.Domain.Implementations
{
    public class EfUsersRepository : IUsersRepository
    {
        private evrostroydbEntities context;
      
        public EfUsersRepository(evrostroydbEntities context)
        {
            this.context = context;
        }

        public void CreateRole(int id, string name)
        {
            Роли role = new Роли()
            {
                ИдРоли = id,
                НазваниеРоли = name
            };

            SaveRole(role);
        }

        public void CreateUser(int id, string name, string phone, string email, string city, string street, string password, int idrole)
        {
            Пользователи user = new Пользователи()
            {
                ИдПользователя = id,
                Имя = name,
                Телефон = phone,
                Email = email,
                Город = city,
                УлицаДомКв = street,
                Пароль = password,
                ИдРоли = idrole,
                ДатаРегистрации = DateTime.Now
            };
            SaveUser(user);
        }

        public void DeleteRole(Роли role)
        {
            context.Роли.Remove(role);
            context.SaveChanges();
        }

        public void DeleteUser(Пользователи user)
        {
            context.Пользователи.Remove(user);
            context.SaveChanges();
        }

        public Роли GetRole(string role)
        {
            return context.Роли.Where(x => x.НазваниеРоли == role).FirstOrDefault();
        }

        public IEnumerable<Роли> GetRoles()
        {
            return context.Роли;
        }

        public Пользователи GetUser(string name)
        {
            return  context.Пользователи.Where(n => n.Имя == name).FirstOrDefault();
        }

        public IEnumerable<Пользователи> GetUsers()
        {
            return context.Пользователи;
        }

        public void SaveRole(Роли role)
        {
            context.Роли.Add(role);
            context.SaveChanges();
        }

        public void SaveUser(Пользователи user)
        {
            context.Пользователи.Add(user);
            context.SaveChanges();
        }
    }
}
