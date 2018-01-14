using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechnicalAssessment.Business.CommonNumber.Impl;
using TechnicalAssessment.Utility.ListToStringUtility;

namespace TechnicalAssessment.UnitTest.Business
{
    [TestFixture]
    public class CommonNumberManagerTest
    {
        private Mock<IListToStringUtility> _listToStringUtility;
        private CommonNumberManager manager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _listToStringUtility = new Mock<IListToStringUtility>();
        }

        [SetUp]
        public void Setup()
        {
            manager = new CommonNumberManager(_listToStringUtility.Object);
        }

        /// <summary>
        /// Test case to get Common number for valid input
        /// </summary>
        [Test]
        public void GetCommonNumberManagerTest_NotNullInput()
        {
            // Arrange
            _listToStringUtility.Setup(x => x.ConvertListToString(It.IsAny<List<string>>())).Returns("{1}");

            // Act
            var output = manager.GetCommonNumber(new string[] { "1" });
            
            // Assert
            Assert.AreEqual(output, "{1}");
        }

        /// <summary>
        /// Test case to get Common number for invalid input
        /// </summary>
        [Test]
        public void GetCommonNumberManagerTest_NullInput()
        {
            // Arrange
            _listToStringUtility.Setup(x => x.ConvertListToString(It.IsAny<List<string>>())).Returns("");

            // Assert
            Assert.Throws<Exception>(() => manager.GetCommonNumber(null));
        }
    }
}
