using Ninject;
using NLayerApp.BL;
using NLayerApp.DAL.Intefaces;
using NLayerApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NLayerApp.DI
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernal;

        public NinjectDependencyResolver()
        {
            kernal = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernal.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernal.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernal.Bind<IService>().To<Service>();
            kernal.Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("DefaultConnection");
           // kernal.Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
