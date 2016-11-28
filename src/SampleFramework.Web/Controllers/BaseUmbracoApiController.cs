using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleFramework.Services.Interfaces;
using Umbraco.Web.WebApi;

namespace SampleFramework.Web.Controllers
{
    public class BaseUmbracoApiController : UmbracoApiController
    {
        public IMapModelService MapModelService { get; set; }

        public IApplicationService ApplicationService { get; set; }

        public IPublishedContentExtensionsWrapper PublishedContentExtensionsWrapper { get; set; }

        public IContentSearchService ContentSearchService { get; set; }

    }
}