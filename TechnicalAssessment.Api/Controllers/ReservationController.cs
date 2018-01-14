using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TechnicalAssessment.Models.Reservation;

namespace TechnicalAssessment.Api.Controllers
{
    [EnableCors(origins: "http://localhost:56082", headers: "*", methods: "*")]
    public class ReservationController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetReservationList()
        {
            try
            {
                var list = new List<Reservation>() { new Reservation() { Id = 1, CustomerName = "Sanket Chaudhary", PeopleCount = 3, Time = new DateTime(2017, 5, 9, 11, 30, 00) },
                    new Reservation() { Id = 2, CustomerName = "Nilam Chaudhary", PeopleCount = 2, Time = new DateTime(2017, 5, 9, 11, 30, 00) } };

                // Create Web Response
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Exception occured while retrieving reservation list: " + ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage BookTable(Reservation reservationDetails)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }
    }
}
