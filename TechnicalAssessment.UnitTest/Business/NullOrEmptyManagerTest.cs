using NUnit.Framework;
using TechnicalAssessment.Business.NullOrEmpty.Impl;

namespace TechnicalAssessment.UnitTest.Business
{
    [TestFixture]
    public class NullOrEmptyManagerTest
    {
        private NullOrEmptyManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new NullOrEmptyManager();
        }

        /// <summary>
        /// Test case to check string
        /// </summary>
        [Test]
        public void CheckStringManagerTest_NullInput()
        {
            // Act
            var responseObj = manager.CheckString(null);
            
            // Assert
            Assert.AreEqual(responseObj, true);
        }

        /// <summary>
        /// Test case to check string empty input
        /// </summary>
        [Test]
        public void CheckStringManagerTest_EmptyInput()
        {
            // Act
            var responseObj = manager.CheckString("");

            // Assert
            Assert.AreEqual(responseObj, true);
        }

        /// <summary>
        /// Test case to check string not null input
        /// </summary>
        [Test]
        public void CheckStringManagerTest_NotNullInput()
        {
            // Act
            var responseObj = manager.CheckString("Sanket");

            // Assert
            Assert.AreEqual(responseObj, false);
        }
    }
}
