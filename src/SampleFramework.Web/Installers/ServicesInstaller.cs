using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SampleFramework.Services;
using SampleFramework.Services.Factories;
using SampleFramework.Services.Interfaces;
using SampleFramework.Services.Wrappers;

namespace SampleFramework.Web.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUmbracoContextFactory>().ImplementedBy<UmbracoContextFactory>());
            container.Register(Component.For<IUmbracoHelperFactory>().ImplementedBy<UmbracoHelperFactory>());
            container.Register(Component.For<IQueryFactory>().ImplementedBy<QueryFactory>());
            container.Register(
                Component.For<IPublishedContentExtensionsWrapperFactory>()
                    .ImplementedBy<PublishedContentExtensionsWrapperFactory>());

            container.Register(
                Component.For<IPublishedContentExtensionsWrapper>().ImplementedBy<PublishedContentExtensionsWrapper>());

            container.Register(Component.For<IMapModelService>().ImplementedBy<MapModelService>());
            container.Register(
                Component.For<IApplicationService>().ImplementedBy<ApplicationService>().LifestylePerWebRequest());
        }
    }
}