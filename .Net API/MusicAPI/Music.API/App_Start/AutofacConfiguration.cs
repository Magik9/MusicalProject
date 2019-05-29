using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Music.BLL.BL;

namespace Music
{
    public static class AutofacConfiguration
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            SetUpRegistration(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void SetUpRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<BranoService>()
                .InstancePerLifetimeScope();
        }
    }
}
