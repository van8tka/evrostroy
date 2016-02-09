using evrostroy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace evrostroy.Web.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            Роли role = new Роли() { НазваниеРоли = roleName };
            evrostroydbEntities context = new evrostroydbEntities();                    
            context.Роли.Add(role);
            context.SaveChanges();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] role = new string[] { };
            using (evrostroydbEntities context = new evrostroydbEntities())
            {
                //получаем пользователя
               Пользователи user = context.Пользователи.Where(x => x.Email == username).FirstOrDefault();
                if (user != null)
                {
                    //получаем роль
                    Роли userrole = context.Роли.Find(user.ИдРоли);
                    if (userrole != null)
                    {
                        role = new string[] { userrole.НазваниеРоли };
                    }
                }
            }
            return role;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            using (evrostroydbEntities context = new evrostroydbEntities())
            {
                Пользователи user = context.Пользователи.Where(x => x.Email == username).FirstOrDefault();
                if (user != null)
                {
                   Роли role = context.Роли.Find(user.ИдРоли);
                    if (role != null && role.НазваниеРоли == roleName)
                        outputResult = true;
                }
            }
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}