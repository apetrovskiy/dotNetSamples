namespace EssentialTools.Infrastructure
{
    using EssentialTools.Models;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBinding();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        public void AddBinding()
        {
            _kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            // 5
            // _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();
            // 6
            // _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);
            // 7
            _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
        }
    }
}