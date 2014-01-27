using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBing();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //  return base.GetControllerInstance(requestContext, controllerType);


            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);

        }
        private void AddBing()
        {
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            // throw new NotImplementedException();
        }
    }
}
