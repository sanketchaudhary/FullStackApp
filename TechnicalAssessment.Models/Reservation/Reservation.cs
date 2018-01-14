using System;

namespace TechnicalAssessment.Models.Reservation
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int PeopleCount { get; set; }
        public DateTime Time { get; set; }
    }
}
