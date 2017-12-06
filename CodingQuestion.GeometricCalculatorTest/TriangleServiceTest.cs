using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingQuestion.GeometricCalculator;
using System.Collections.Generic;
using CodingQuestion.Entity;
using System.Linq;

namespace CodingQuestion.GeometricCalculatorTest
{
    [TestClass]
    public class TriangleServiceTest
    {
        #region Tests for calculating coordinate
        [TestMethod]
        public void GetCoordinates_for_rowA_and_column1()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> expectedCoordinate = new List<Coordinate> {
                new Coordinate{X=0,Y=0},
                new Coordinate{X=0,Y=10},
                new Coordinate{X=10,Y=10},
            };

            //Act
            var result = triangle.GetCoordinate('A', 1);

            //Assert
            Assert.IsTrue(AreListsEqual(expectedCoordinate, result));
        }

        [TestMethod]
        public void GetCoordinates_for_rowA_and_column2()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> expectedCoordinate = new List<Coordinate> {
                new Coordinate{X=0,Y=0},
                new Coordinate{X=10,Y=0},
                new Coordinate{X=10,Y=10},
            };

            //Act
            var result = triangle.GetCoordinate('A', 2);

            //Assert
            Assert.IsTrue(AreListsEqual(expectedCoordinate, result));
        }
        [TestMethod]
        public void GetCoordinates_for_rowF_and_column11()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> expectedCoordinate = new List<Coordinate> {
                new Coordinate{X=50,Y=50},
                new Coordinate{X=50,Y=60},
                new Coordinate{X=60,Y=60},
            };

            //Act
            var result = triangle.GetCoordinate('F', 11);

            //Assert
            Assert.IsTrue(AreListsEqual(expectedCoordinate, result));
        }

        [TestMethod]
        public void GetCoordinates_for_rowF_and_column12()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> expectedCoordinate = new List<Coordinate> {
                new Coordinate{X=50,Y=50},
                new Coordinate{X=60,Y=50},
                new Coordinate{X=60,Y=60},
            };

            //Act
            var result = triangle.GetCoordinate('F', 12);

            //Assert
            Assert.IsTrue(AreListsEqual(expectedCoordinate, result));
        }
        #endregion

        #region Tests for calculating row and column
        [TestMethod]
        public void GetCellLocation_of_rowA_and_column1()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> coordinates = new List<Coordinate> {
                new Coordinate{X=0,Y=0},
                new Coordinate{X=0,Y=10},
                new Coordinate{X=10,Y=10},
            };

            //Act
            var result = triangle.GetTriangleLocation(coordinates);

            //Assert
            Assert.AreEqual(result.Row, 'A');
            Assert.AreEqual(result.Column, 1);
        }

        [TestMethod]
        public void GetCellLocation_of_rowA_and_column2()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> coordinates = new List<Coordinate> {
                new Coordinate{X=0,Y=0},
                new Coordinate{X=10,Y=0},
                new Coordinate{X=10,Y=10},
            };

            //Act
            var result = triangle.GetTriangleLocation(coordinates);

            //Assert
            Assert.AreEqual(result.Row, 'A');
            Assert.AreEqual(result.Column, 2);
        }
        [TestMethod]
        public void GetCellLocation_of_rowF_and_column11()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> coordinates = new List<Coordinate> {
                new Coordinate{X=50,Y=50},
                new Coordinate{X=50,Y=60},
                new Coordinate{X=60,Y=60},
            };

            //Act
            var result = triangle.GetTriangleLocation(coordinates);

            //Assert
            Assert.AreEqual(result.Row, 'F');
            Assert.AreEqual(result.Column, 11);
        }

        [TestMethod]
        public void GetCellLocation_of_rowF_and_column12()
        {
            //Arrange
            var triangle = new TriangleService();
            List<Coordinate> coordinates = new List<Coordinate> {
                new Coordinate{X=50,Y=50},
                new Coordinate{X=60,Y=50},
                new Coordinate{X=60,Y=60},
            };

            //Act
            var result = triangle.GetTriangleLocation(coordinates);

            //Assert
            Assert.AreEqual(result.Row, 'F');
            Assert.AreEqual(result.Column,12);
        }
        #endregion

        private bool AreListsEqual(IList<Coordinate> firstCoordinates,
            IList<Coordinate> secondCoordinates)
        {
            if (firstCoordinates?.Count != secondCoordinates?.Count)
                return false;

            foreach (var coordinate in firstCoordinates)
            {
                if (!secondCoordinates.Where(r => r.X == coordinate.X
                        && r.Y == coordinate.Y).Any())
                    return false;
            }

            return true;
        }

    }
}

