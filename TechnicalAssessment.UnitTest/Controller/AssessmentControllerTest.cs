using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using TechnicalAssessment.Business.CommonNumber;
using TechnicalAssessment.Business.NullOrEmpty;
using TechnicalAssessment.Business.PositiveDivisor;
using TechnicalAssessment.Business.Triangle;
using TechnicalAssessment.Api.Controllers;
using model = TechnicalAssessment.Models.Triangle;

namespace TechnicalAssessment.UnitTest.Controller
{
    [TestFixture]
    public class AssessmentControllerTest
    {
        private Mock<INullOrEmptyManager> _nullOrEmptyManager;
        private Mock<IPositiveDivisorManager> _positiveDivisorManager;
        private Mock<ICommonNumberManager> _commonNumberManager;
        private Mock<ITriangleManager> _triangleManager;
        private AssessmentController controller;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _nullOrEmptyManager = new Mock<INullOrEmptyManager>();
            _positiveDivisorManager = new Mock<IPositiveDivisorManager>();
            _commonNumberManager = new Mock<ICommonNumberManager>();
            _triangleManager = new Mock<ITriangleManager>();
        }

        [SetUp]
        public void Setup()
        {
            controller = new AssessmentController(_nullOrEmptyManager.Object, _positiveDivisorManager.Object, _commonNumberManager.Object, _triangleManager.Object) {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
        }

        /// <summary>
        /// Test case to check null string
        /// </summary>
        [Test]
        public void CheckStringTest_NullInput()
        {
            // Arrange
            _nullOrEmptyManager.Setup(x => x.CheckString(It.IsAny<string>())).Returns(true);

            // Act
            var responseObj = controller.CheckString(null);
            var responseModel = responseObj?.Content?.ReadAsAsync<bool>()?.Result;

            // Assert
            Assert.AreEqual(responseModel, true);
        }

        /// <summary>
        /// Test case to check not null string
        /// </summary>
        [Test]
        public void CheckStringTest_ValidInput_NotNull()
        {
            // Arrange
            _nullOrEmptyManager.Setup(x => x.CheckString(It.IsAny<string>())).Returns(false);

            // Act
            var responseObj = controller.CheckString("Sanket");
            var responseModel = responseObj?.Content?.ReadAsAsync<bool>()?.Result;

            // Assert
            Assert.AreEqual(responseModel, false);
        }

        /// <summary>
        /// Test case to check empty string
        /// </summary>
        [Test]
        public void CheckStringTest_ValidInput_Empty()
        {
            // Arrange
            _nullOrEmptyManager.Setup(x => x.CheckString(It.IsAny<string>())).Returns(true);

            // Act
            var responseObj = controller.CheckString("");
            var responseModel = responseObj?.Content?.ReadAsAsync<bool>()?.Result;

            // Assert
            Assert.AreEqual(responseModel, true);
        }

        /// <summary>
        /// Test case to get positive divisor for null input
        /// </summary>
        [Test]
        public void GetPositiveDivisorsTest_Invalid_NullInput()
        {
            // Arrange
            _positiveDivisorManager.Setup(x => x.CalculatePositiveDivisor(It.IsAny<int>())).Returns("");

            // Act
            var responseObj = controller.GetPositiveDivisors(null);
            
            // Assert
            Assert.AreEqual(responseObj.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Test case to get positive divisor for null input
        /// </summary>
        [Test]
        public void GetPositiveDivisorsTest_Invalid_EmptyInput()
        {
            // Arrange
            _positiveDivisorManager.Setup(x => x.CalculatePositiveDivisor(It.IsAny<int>())).Returns("");

            // Act
            var responseObj = controller.GetPositiveDivisors("");

            // Assert
            Assert.AreEqual(responseObj.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Test case to get positive divisor for not null input
        /// </summary>
        [Test]
        public void GetPositiveDivisorsTest_ValidInput_NotNullInput()
        {
            // Arrange
            _positiveDivisorManager.Setup(x => x.CalculatePositiveDivisor(It.IsAny<int>())).Returns("{1,2}");

            // Act
            var responseObj = controller.GetPositiveDivisors("2");
            var responseModel = responseObj?.Content?.ReadAsAsync<string>()?.Result;

            // Assert
            Assert.AreEqual(responseModel, "{1,2}");
        }

        /// <summary>
        /// Test case to get common number for null input
        /// </summary>
        [Test]
        public void GetCommonNumberTest_Invalid_NullInput()
        {
            // Arrange
            _commonNumberManager.Setup(x => x.GetCommonNumber(It.IsAny<IEnumerable<string>>())).Returns("");

            // Act
            var responseObj = controller.GetCommonNumber(null);

            // Assert
            Assert.AreEqual(responseObj.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Test case to get common number for not null input
        /// </summary>
        [Test]
        public void GetCommonNumberTest_Valid_NotNullInput()
        {
            // Arrange
            _commonNumberManager.Setup(x => x.GetCommonNumber(It.IsAny<IEnumerable<string>>())).Returns("{1}");

            // Act
            var responseObj = controller.GetCommonNumber(new string[] {"1"});
            var responseModel = responseObj?.Content?.ReadAsAsync<string>()?.Result;

            // Assert
            Assert.AreEqual(responseModel, "{1}");
        }

        /// <summary>
        /// Test case to get Traingle area for null input
        /// </summary>
        [Test]
        public void GetTraingleAreaTest_Invalid_NullInput()
        {
            // Arrange
            _triangleManager.Setup(x => x.CalculateTriangleArea(It.IsAny<model.Triangle>())).Returns(0);

            // Act
            var responseObj = controller.GetTriangleArea(null);

            // Assert
            Assert.AreEqual(responseObj.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Test case to get Traingle area for valid input
        /// </summary>
        [Test]
        public void GetTraingleAreaTest_Valid_NotNullInput()
        {
            // Arrange
            _triangleManager.Setup(x => x.CalculateTriangleArea(It.IsAny<model.Triangle>())).Returns(6);

            // Act
            var responseObj = controller.GetTriangleArea(new model.Triangle() { SideOne = 3, SideTwo = 4, SideThree = 5 });
            var responseModel = responseObj?.Content?.ReadAsAsync<string>()?.Result;

            // Assert
            Assert.AreEqual(responseModel, "6");
        }
    }
}
