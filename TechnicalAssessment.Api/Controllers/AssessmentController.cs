using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TechnicalAssessment.Business.CommonNumber;
using TechnicalAssessment.Business.CommonNumber.Impl;
using TechnicalAssessment.Business.NullOrEmpty;
using TechnicalAssessment.Business.NullOrEmpty.Impl;
using TechnicalAssessment.Business.PositiveDivisor;
using TechnicalAssessment.Business.PositiveDivisor.Impl;
using TechnicalAssessment.Business.Triangle;
using TechnicalAssessment.Business.Triangle.Impl;
using TechnicalAssessment.Models.Triangle;

namespace TechnicalAssessment.Api.Controllers
{
    [RoutePrefix("api")]
    [EnableCors(origins: "http://localhost:56082", headers: "*", methods: "*")]
    public class AssessmentController : ApiController
    {
        #region Properties
        INullOrEmptyManager _nullOrEmptyManager;
        IPositiveDivisorManager _positiveDivisorManager;
        ICommonNumberManager _commonNumberManager;
        ITriangleManager _triangleManager;
        #endregion

        #region Constructors
        public AssessmentController() : this(new NullOrEmptyManager(), new PositiveDivisorManager(), new CommonNumberManager(), new TriangleManager())
        { }

        /// <summary>
        /// Parameterized Assessment constructor with dependencies
        /// </summary>
        /// <param name="nullOrEmptyManager"></param>
        public AssessmentController(
            INullOrEmptyManager nullOrEmptyManager,
            IPositiveDivisorManager positiveDivisorManager,
            ICommonNumberManager commonNumberManager,
            ITriangleManager triangleManager)
        {
            _nullOrEmptyManager = nullOrEmptyManager;
            _positiveDivisorManager = positiveDivisorManager;
            _commonNumberManager = commonNumberManager;
            _triangleManager = triangleManager;
        }
        #endregion

        /// <summary>
        /// Web GET method to check string if it is null or empty
        /// </summary>
        /// <param name="inputVal">Input string</param>
        /// <returns>Http Web response message</returns>
        [HttpGet]
        public HttpResponseMessage CheckString(string inputVal)
        {
            try
            {
                // Call Manager class to check string
                var result = _nullOrEmptyManager.CheckString(inputVal);

                // Create Web Response
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception occured while retrieving date difference: " + ex);
            }
        }

        /// <summary>
        /// Web GET method to calculate positive divisors
        /// </summary>
        /// <param name="number">Number as input</param>
        /// <returns>Http Web Message</returns>
        [HttpGet]
        public HttpResponseMessage GetPositiveDivisors(string number)
        {
            try
            {
                // Call manager class if number is not null or empty else return error response
                if (!string.IsNullOrEmpty(number))
                {
                    // Call Manager class to check string
                    var result = _positiveDivisorManager.CalculatePositiveDivisor(Convert.ToInt32(number));

                    // Create Web Response
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    // If number is null, create Error Web response
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Number is null or empty");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception occured while retrieving date difference: " + ex);
            }
        }

        /// <summary>
        /// Web POST method to get Common number from list of numbers
        /// </summary>
        /// <param name="numberArray">List of numbers</param>
        /// <returns>Http Web Message</returns>
        [HttpPost]
        public HttpResponseMessage GetCommonNumber(string[] numberArray)
        {
            try
            {
                // Call manager class if number is not null or empty else return error response
                if (numberArray != null)
                {
                    // Call Manager class to check string
                    var result = _commonNumberManager.GetCommonNumber(numberArray);

                    // Create Web Response
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    // If number is null, create Error Web response
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Number is null or empty");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception occured while retrieving date difference: " + ex);
            }
        }

        /// <summary>
        /// Web POST method to get triangle area
        /// </summary>
        /// <param name="requestInput">Triangle model with all sides</param>
        /// <returns>Http Web Response Message</returns>
        [Route("GetTriangleArea")]
        [HttpPost]
        public HttpResponseMessage GetTriangleArea(Triangle requestInput)
        {
            try
            {
                if (requestInput != null)
                {
                    // Call business method and retrieve traingle area
                    var triangleArea = _triangleManager.CalculateTriangleArea(requestInput);

                    // Return reponse
                    return Request.CreateResponse<string>(HttpStatusCode.OK, triangleArea.ToString());
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Input model is null");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Exception occured while retrieving Triangle Area", ex);
            }
        }
    }
}
