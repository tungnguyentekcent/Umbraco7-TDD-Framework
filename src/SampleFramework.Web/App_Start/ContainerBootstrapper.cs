using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SampleFramework.Web.App_Start
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        public ContainerBootstrapper(IWindsorContainer container)
        {
            Container = container;
        }

        public IWindsorContainer Container { get; }

        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            return new ContainerBootstrapper(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}