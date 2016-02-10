using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evrostroy.Domain.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<Пользователи> GetUsers();
        IEnumerable<Роли> GetRoles();

        Пользователи GetUser(string name);
        Роли GetRole(string role);
        void CreateUser(int id, string name, string phone, string email, string city, string street, string password, int idrole, DateTime tim);
        void DeleteUser(Пользователи user);
        void SaveUser(Пользователи user);
        void CreateRole(int id, string name);
        void DeleteRole(Роли role);
        void SaveRole(Роли role);
    }
}
