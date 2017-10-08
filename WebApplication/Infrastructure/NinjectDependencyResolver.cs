using TestingSystem.Domain.Abstract;
using TestingSystem.Domain.Concrete;
using TestingSystem.Domain.Entities;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace WebApplication.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            Configure();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Configure()
        {
            kernel.Bind<DbContext>().To<EFDbContext>().InRequestScope();
            kernel.Bind<ITestRepository>().To<EFTestRepository>();
            kernel.Bind<IQuestionRepository>().To<EFQuestionRepository>();
            kernel.Bind<IAnswerRepository>().To<EFAnswerRepository>();
            kernel.Bind<IUserRepository>().To<EFUserRepository>();
            kernel.Bind<IRoleRepository>().To<EFRoleRepository>();
            kernel.Bind<IStatisticRepository>().To<EFStatisticRepository>();
            kernel.Bind<IPassTestService>().To<PassTestService>();
        }
    }
}