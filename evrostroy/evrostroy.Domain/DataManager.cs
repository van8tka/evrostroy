using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evrostroy.Domain.Interfaces;

namespace evrostroy.Domain
{
   
    public class DataManager
    {//в этом классе ценрализовано происходит обмен данными
     //этот класс будем внедрять в конструктор каждого контроллера
   
        private IUsersRepository usersRepository;

        public DataManager(IUsersRepository usersRepository)
        {           
            this.usersRepository = usersRepository; 
        }



        //объявим свойства через которые будем возвращать репозитории требуемые для работы

      

        public IUsersRepository UsersRepository
        {
            get { return usersRepository; }
        }
              
    }
}
