using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TechnicalAssessment.Business.PositiveDivisor.Impl;
using TechnicalAssessment.Utility.ListToStringUtility;

namespace TechnicalAssessment.UnitTest.Business
{
    [TestFixture]
    public class PositiveDivisorManagerTest
    {
        private Mock<IListToStringUtility> _listToStringUtility;
        private PositiveDivisorManager manager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _listToStringUtility = new Mock<IListToStringUtility>();
        }

        [SetUp]
        public void Setup()
        {
            manager = new PositiveDivisorManager(_listToStringUtility.Object);
        }

        /// <summary>
        /// Test case to get Positive Divisor for valid input
        /// </summary>
        [Test]
        public void CalculatePositiveDivisorManagerTest_NotNullInput()
        {
            // Arrange
            _listToStringUtility.Setup(x => x.ConvertListToString(It.IsAny<List<string>>())).Returns("{1,2}");

            // Act
            var output = manager.CalculatePositiveDivisor(2);

            // Assert
            Assert.AreEqual(output, "{1,2}");
        }

        /// <summary>
        /// Test case to get Positive divisor for invalid input
        /// </summary>
        [Test]
        public void CalculatePositiveDivisorManagerTest_NullInput()
        {
            // Arrange
            _listToStringUtility.Setup(x => x.ConvertListToString(It.IsAny<List<string>>())).Returns("");

            // Act
            var output = manager.CalculatePositiveDivisor(0);

            // Assert
            Assert.AreEqual(output, "");
        }
    }
}
