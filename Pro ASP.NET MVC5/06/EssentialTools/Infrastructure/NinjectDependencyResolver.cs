namespace EssentialTools.Infrastructure
{
    using EssentialTools.Models;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Ninject.Web.Common;

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
            // <09
            // _kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            // 05
            // _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>();
            // 06
            // _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);
            // 07
            _kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);
            // 08
            _kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
            // 10
            _kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();
        }
    }
}