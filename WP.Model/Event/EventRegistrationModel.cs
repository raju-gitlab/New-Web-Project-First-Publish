using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Model.Event
{
    public class EventRegistrationModel : BaseModel
    {
        public int Id { get; set; }
        public string EventId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TicketQuantity { get; set; }
        public string  PhoneNumber { get; set; }
        public string RemainSeats { get; set; }
        public string TicketId { get; set; }
        [DefaultValue(false)]
        public string RegistrationStatus { get; set; }
        public int EventScheduleID { get; set; }
        public DateTimeOffset BookingDate { get; set; }
    }
}
