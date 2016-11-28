using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SampleFramework.Web.Controllers;
using SampleFramework.Web.Tests.Abstractions;

namespace SampleFramework.Web.Tests
{
    [TestFixture]
    public class TransactionsApiControllerTests : BaseUmbracoApiControllerTests
    {
        [Test]
        public void GetTransactions_ShouldReturnListOfString()
        {
            // Arrange
            var controller = new TransactionsApiController();

            // Act
            var result = controller.GetTransactions();

            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(string));
        }
    }
}
