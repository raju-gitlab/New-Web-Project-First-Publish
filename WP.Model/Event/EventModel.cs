using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Event;

namespace WP.Model
{
    public class OrganizationModel : BaseModel
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationGuid { get; set; }
        public string OrganizationDescription { get; set; }
        public string Contact { get; set; }
    }
    public class EventModel : OrganizationModel
    {
        public string EventName { get; set; }
        public string Place { get; set; }
        public DateTimeOffset PremireDate { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public bool PreRegistration { get; set; }
        public int TotalInvites { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public string EventDescription { get; set; }
        public DateTimeOffset EventExpireDate { get; set; }
        public string Location { get; set; }
        public int TotalRegistration { get; set; }
        public int Year { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public EventRegistrationModel Registration { get; set; }
    }
     
}
