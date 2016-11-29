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
        public void GetPageModel_PassInDocTypeAliasOfCurrentPage_ReturnPageModelWithInfoOfCurrentPage()
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
        public void GetPageModel_PassInDocTypeAliasNotOfCurrentPage_ShouldGetFirstNodeOfDocTypeAliasAndReturnPageModelWithInfoOfThatNode()
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
        public void GetPageModel_PassInDocTypeAlias_CurrentPageNotExist_ShouldGetFirstNodeOfDocTypeAliasAndReturnPageModelWithInfoOfThatNode()
        {
            // Arrange
            const string docTypeAlias = "testAlias";

            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);
            
            var nodeMock = new Mock<INode>();
            nodeMock.Setup(x => x.NodeTypeAlias).Returns(docTypeAlias);
            QueryFactoryMock.Setup(x => x.GetCurrentNode()).Returns((INode) null);
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
        public void GetPageModel_PassInDocumentTypeAlias_PageNodeNotExist_ThrowNullException()
        {
            // Arrange
            const string docTypeAlias = "testAlias";

            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);
            
            QueryFactoryMock.Setup(x => x.GetCurrentNode()).Returns((INode) null);
            QueryFactoryMock.Setup(x => x.GetFirstNodeOfType(docTypeAlias)).Returns((INode)null);

            // Assert
            Assert.Throws<NullReferenceException>(() => applicationService.GetPageModel<StubModel>(docTypeAlias));
        }

        [Test]
        public void GetNode_PassInDocumentTypeAlias_NodeExists_ReturnsNode()
        {
            // Arrange
            const string docTypeAlias = "testAlias";
            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);

            var mockNewsletterFolderNode = new Mock<INode>();
            QueryFactoryMock.Setup(x => x.GetFirstNodeOfType(docTypeAlias)).Returns(mockNewsletterFolderNode.Object);

            // Act
            var result = applicationService.GetNode(docTypeAlias);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockNewsletterFolderNode.Object, result);
        }

        [Test]
        public void GetNode_PassInDocumentTypeAlias_NodeNotExist_ThrowNullReferenceException()
        {
            // Arrange
            const string docTypeAlias = "testAlias";

            var applicationService = new ApplicationService(QueryFactoryMock.Object, UmbracoContextFactoryMock.Object,
                UmbracoHelperFactoryMock.Object, PublishedContentExtensionsWrapperFactoryMock.Object);

            INode nullNode = null;
            QueryFactoryMock.Setup(x => x.GetFirstNodeOfType(docTypeAlias)).Returns(nullNode);

            // Assert
            Assert.Throws<NullReferenceException>(() => applicationService.GetNode(docTypeAlias));
        }
    }

    class StubModel : BasePage
    {
    }
}
