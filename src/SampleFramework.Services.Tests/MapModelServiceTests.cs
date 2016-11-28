using System;
using System.Collections.Generic;
using AutoMapper;
using NUnit.Framework;

namespace SampleFramework.Services.Tests
{
    [TestFixture]
    public class MapModelServiceTests
    {
        #region Tests

        [Test]
        public void Map_SpecifySourceTypeAndDestinationType_ReturnsMappedDestinationObject()
        {
            // Arrange
            var srcObj = new SourceObject()
            {
                Id = 1,
                Name = "map model service",
                Create = new DateTime(2000, 1, 1),
                Children = new List<string>() { "Child 1", "Child 2" }
            };

            var mapModelService = new MapModelService();
            Mapper.CreateMap<SourceObject, DestinationObject>();

            // Act
            var destObj = mapModelService.Map<SourceObject, DestinationObject>(srcObj);

            // Assert
            Assert.AreEqual(srcObj.Id, destObj.Id);
            Assert.AreEqual(srcObj.Name, destObj.Name);
            Assert.AreEqual(srcObj.Create, destObj.Create);
            Assert.AreEqual(srcObj.Children, destObj.Children);
        }

        [Test]
        public void Map_SpecifyDestinationTypeOnly_ReturnsMappedDestinationObject()
        {
            // Arrange
            var srcObj = new SourceObject()
            {
                Id = 1,
                Name = "map model service",
                Create = new DateTime(2000, 1, 1),
                Children = new List<string>() { "Child 1", "Child 2" }
            };

            var mapModelService = new MapModelService();
            Mapper.CreateMap<SourceObject, DestinationObject>();

            // Act
            var destObj = mapModelService.Map<DestinationObject>(srcObj);

            // Assert
            Assert.AreEqual(srcObj.Id, destObj.Id);
            Assert.AreEqual(srcObj.Name, destObj.Name);
            Assert.AreEqual(srcObj.Create, destObj.Create);
            Assert.AreEqual(srcObj.Children, destObj.Children);
        }

        #endregion


        #region Private Classes

        private class SourceObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Create { get; set; }
            public List<string> Children { get; set; }
        }

        private class DestinationObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Create { get; set; }
            public List<string> Children { get; set; }
        }

        #endregion // Private Classes
    }
}
