using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SampleFramework.Web.Factories;
using Umbraco.Web.WebApi;

namespace SampleFramework.Web.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<IController>()
                    .If(c => c.Name.EndsWith("Controller"))
                    .LifestyleTransient());

            container.Register(
                Classes.FromAssemblyInThisApplication().BasedOn<UmbracoApiController>().LifestyleTransient());

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }
}