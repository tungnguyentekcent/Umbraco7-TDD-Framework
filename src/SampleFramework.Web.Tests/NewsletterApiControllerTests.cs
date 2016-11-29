using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SampleFramework.Domain.Models;
using SampleFramework.Shared.Constants;
using SampleFramework.Web.ApiControllers;
using SampleFramework.Web.Tests.Abstractions;

namespace SampleFramework.Web.Tests
{
    [TestFixture]
    public class NewsletterApiControllerTests : BaseUmbracoApiControllerTests
    {
        [Test]
        public void GetTransactions_ShouldReturnListOfNewsletters()
        {
            // Arrange
            var controller = new NewsletterApiController
            {
                ApplicationService = ApplicationServiceMock.Object
            };

            var newsletters = new List<Newsletter>
            {
                new Newsletter { Id = 1, Email = "test1@test.com"},
                new Newsletter { Id = 2, Email = "test2@test.com"}
            };

            var newsletterFolder = new NewsletterFolder {Newsletters = newsletters};
            ApplicationServiceMock.Setup(x => x.GetPageModel<NewsletterFolder>(DocTypeAliases.NewsletterFolder.Alias))
                .Returns(newsletterFolder);

            // Act
            var result = controller.GetNewsletters();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newsletters, result);
        }
    }
}
