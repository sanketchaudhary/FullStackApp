using Moq;
using NUnit.Framework;
using System;
using TechnicalAssessment.Business.Triangle.Impl;
using TechnicalAssessment.Utility.Traingle;
using model = TechnicalAssessment.Models.Triangle;

namespace TechnicalAssessment.UnitTest.Business
{
    public class TriangleManagerTest
    {
        private Mock<ITraingleUtility> _triangleUtility;
        private TriangleManager manager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _triangleUtility = new Mock<ITraingleUtility>();
        }

        [SetUp]
        public void Setup()
        {
            manager = new TriangleManager(_triangleUtility.Object);
        }

        /// <summary>
        /// Test case to get calculate triangle area for valid input
        /// </summary>
        [Test]
        public void CalculateTriangleAreaManagerTest_NotNullInput()
        {
            // Arrange
            _triangleUtility.Setup(x => x.CalculateArea(It.IsAny<model.Triangle>())).Returns(6);

            // Act
            var output = manager.CalculateTriangleArea(new model.Triangle() { SideOne = 3, SideTwo = 4, SideThree = 5 });

            // Assert
            Assert.AreEqual(output, 6);
        }

        /// <summary>
        /// Test case to get calculate triangle area for negative side
        /// </summary>
        [Test]
        public void CalculateTriangleAreaManagerTest_NegativeSide()
        {
            // Arrange
            _triangleUtility.Setup(x => x.CalculateArea(It.IsAny<model.Triangle>())).Returns(6);

            // Assert
            Assert.Throws<Exception>(() => manager.CalculateTriangleArea(new model.Triangle() { SideOne = -3, SideTwo = 4, SideThree = 5 }));
        }

        /// <summary>
        /// Test case to get calculate triangle area for invalid side
        /// </summary>
        [Test]
        public void CalculateTriangleAreaManagerTest_InvalidSide()
        {
            // Arrange
            _triangleUtility.Setup(x => x.CalculateArea(It.IsAny<model.Triangle>())).Returns(6);

            // Assert
            Assert.Throws<Exception>(() => manager.CalculateTriangleArea(new model.Triangle() { SideOne = 1, SideTwo = 2, SideThree = 7 }));
        }
    }
}
