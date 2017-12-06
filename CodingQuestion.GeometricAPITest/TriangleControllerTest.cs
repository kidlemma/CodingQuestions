using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CodingQuestion.Entity;
using System.Collections.Generic;
using CodingQuestion.GeometricInterface;
using CodingQuestion.GeometricAPI.Controllers;
using System.Web.Http;
using System.Web.Http.Results;

namespace CodingQuestion.GeometricAPITest
{
    [TestClass]
    public class TriangleControllerTest
    {
        #region Tests for calculating coordinate
        [TestMethod]
        public void GetCoordinate_for_rowA_and_column1()
        {
            // Arrange
            var mockRepository = new Mock<ITriangleService>();
            mockRepository.Setup(x => x.GetCoordinate('A', 1))
                .Returns(new List<Coordinate> {
                new Coordinate{X=0,Y=0},
                new Coordinate{X=0,Y=10},
                new Coordinate{X=10,Y=10},
            });

            var controller = new TriangleController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.GetCoordinate('A', 1);
            var contentResult = actionResult as OkNegotiatedContentResult<IList<Coordinate>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count);
        }

        
        #endregion

        #region Tests for calculating row and column
        //TODO: Add tests
        #endregion
    }
}
