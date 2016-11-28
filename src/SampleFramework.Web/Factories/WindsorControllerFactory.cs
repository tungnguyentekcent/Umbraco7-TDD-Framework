using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace SampleFramework.Web.Factories
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        #region Private Variables

        private readonly IWindsorContainer _container;

        #endregion // Private Variables


        #region Constructors

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this._container = container;
        }

        #endregion // Constructors


        #region Public Methods

        #region ReleaseController
        public override void ReleaseController(IController controller)
        {
            this._container.Release(controller);
        }
        #endregion

        #endregion // Public Methods


        #region Protected Methods

        #region GetControllerInstance
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null && this._container.Kernel.HasComponent(controllerType))
            {
                return (IController)this._container.Resolve(controllerType);
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }
        #endregion

        #endregion // Protected Methods
    }
}