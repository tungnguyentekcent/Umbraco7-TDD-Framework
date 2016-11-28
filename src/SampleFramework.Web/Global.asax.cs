using SampleFramework.Web.App_Start;
using System;
using System.Web.Http;
using Umbraco.Web;
using WebApiContrib.IoC.CastleWindsor;

namespace SampleFramework.Web
{
    public class SampleFrameworkApplication : UmbracoApplication
    {
        private ContainerBootstrapper _containerBootstrapper;

        protected override void OnApplicationStarting(object sender, EventArgs e)
        {
            _containerBootstrapper = ContainerBootstrapper.Bootstrap();

            // setup the webapi dependency resolver to use Castle Windsor
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorResolver(_containerBootstrapper.Container);

            AutoMapperConfig.RegisterAutoMapper();

            base.OnApplicationStarting(sender, e);
        }

        protected override void OnApplicationEnd(object sender, EventArgs e)
        {
            _containerBootstrapper.Dispose();

            base.OnApplicationEnd(sender, e);
        }
    }
}