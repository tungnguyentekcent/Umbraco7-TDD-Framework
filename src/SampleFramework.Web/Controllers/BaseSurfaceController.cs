using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleFramework.Services.Interfaces;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace SampleFramework.Web.Controllers
{
    public class BaseSurfaceController : SurfaceController
    {
        private readonly UmbracoHelper _umbracoHelper;

        public override UmbracoHelper Umbraco => _umbracoHelper ?? base.Umbraco;

        public IMemberServiceFactory MemberServiceFactory { get; set; }

        public IMembershipHelperFactory MembershipHelperFactory { get; set; }

        protected IMemberService MemberService => MemberServiceFactory.GetMemberService(this);

        protected IMembershipHelperWrapper MembershipHelperWrapper => MembershipHelperFactory.GetMembershipHelperWrapper(this);

        public IContentServiceFactory ContentServiceFactory { get; set; }

        public BaseSurfaceController()
        {
        }

        public BaseSurfaceController(UmbracoContext umbracoContext) : base(umbracoContext)
        {
        }

        public BaseSurfaceController(UmbracoContext umbracoContext, UmbracoHelper umbracoHelper)
            : base(umbracoContext)
        {
            _umbracoHelper = umbracoHelper;
        }
    }
}