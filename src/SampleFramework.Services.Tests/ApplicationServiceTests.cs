using System;
using Moq;
using NUnit.Framework;
using SampleFramework.Domain.Models;
using SampleFramework.Services.Tests.Abstractions;
using umbraco.interfaces;

namespace SampleFramework.Services.Tests
{
    [TestFixture]
    public class ApplicationServiceTests : BaseServiceTests
    {
        [Test]
        public void GetPageModel_OfStubModelType_PassInDocTypeAliasOfCurrentPage_ReturnStubModelWithInfoOfCurrentPage()
        {
            // Arrange
            const string docTypeAlias = "testAlias";

            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);

            var currentNodeMock = new Mock<INode>();
            currentNodeMock.Setup(x => x.NodeTypeAlias).Returns(docTypeAlias);
            QueryFactoryMock.Setup(x => x.GetCurrentNode()).Returns(currentNodeMock.Object);

            var stubModel = new StubModel();
            PublishedContentExtensionsWrapperMock.Setup(x => x.As<StubModel>(currentNodeMock.Object.Id)).Returns(stubModel);

            // Act
            var result = applicationService.GetPageModel<StubModel>(docTypeAlias);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(stubModel, result);
        }

        [Test]
        public void GetPageModel_OfStubModelType_PassInDocTypeAliasNotOfCurrentPage_ShouldGetFirstNodeOfDocTypeAliasAndReturnStubModelWithInfoOfThatNode()
        {
            // Arrange
            const string docTypeAlias = "testAlias";
            const string currentNodeTypeAlias = "currentNodeAlias";

            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);

            var currentNodeMock = new Mock<INode>();
            currentNodeMock.Setup(x => x.NodeTypeAlias).Returns(currentNodeTypeAlias);
            var nodeMock = new Mock<INode>();
            nodeMock.Setup(x => x.NodeTypeAlias).Returns(docTypeAlias);
            QueryFactoryMock.Setup(x => x.GetCurrentNode()).Returns(currentNodeMock.Object);
            QueryFactoryMock.Setup(x => x.GetFirstNodeOfType(docTypeAlias)).Returns(nodeMock.Object);

            var stubModel = new StubModel();
            PublishedContentExtensionsWrapperMock.Setup(x => x.As<StubModel>(nodeMock.Object.Id)).Returns(stubModel);

            // Act
            var result = applicationService.GetPageModel<StubModel>(docTypeAlias);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(stubModel, result);
        }

        [Test]
        public void GetPageModel_OfStubModelType_PassInDocumentTypeAlias_PageNodeNotExist_ThrowNullException()
        {
            // Arrange
            const string docTypeAlias = "testAlias";

            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);
            
            QueryFactoryMock.Setup(x => x.GetCurrentNode()).Returns((INode) null);
            QueryFactoryMock.Setup(x => x.GetFirstNodeOfType(docTypeAlias)).Returns((INode)null);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => applicationService.GetPageModel<StubModel>(docTypeAlias));
        }
    }

    class StubModel : BasePage
    {
    }
}
