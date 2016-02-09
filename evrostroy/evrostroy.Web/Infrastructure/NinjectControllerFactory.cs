using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evrostroy.Domain.Implementations;
using evrostroy.Domain.Interfaces;
using Ninject;
using evrostroy.Domain;

namespace evrostroy.Web.Infrastructure
{
    public class NinjectControllerFactory : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectControllerFactory(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUsersRepository>().To<EfUsersRepository>();
          
        }
    }
}