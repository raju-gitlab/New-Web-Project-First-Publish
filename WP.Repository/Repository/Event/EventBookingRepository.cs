using CommonApplicationFramework.ConfigurationHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model.Event;
using WP.Repository.IRepository.IEvent;

namespace WP.Repository.Repository.Event
{
    public class EventBookingRepository : IEventBookingRepository
    {
        #region GET
        #region GetAllRegistrationDetailsByEventId
        public List<EventRegistrationModel> GetByEventId(string EventGuid)
        {
           try
            {
                List<EventRegistrationModel> GetAllDetails = new List<EventRegistrationModel>();
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string querry = QueryConfig.BookQuerySettings["GetEventRegistrationDetails"].ToString();
                    using (SqlCommand cmd = new SqlCommand(querry, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@EventGuid", EventGuid));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            EventRegistrationModel GetDetails = new EventRegistrationModel();
                            GetDetails.FirstName = rdr["FirstName"].ToString();
                            GetDetails.LastName = rdr["LastName"].ToString();
                            GetDetails.TicketId = rdr["TicketId"].ToString();
                            GetAllDetails.Add(GetDetails);
                        }
                    }
                    return GetAllDetails;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion
        #endregion

        #region POST

        #region BookEventTicket
        public int BookEventTicket(EventRegistrationModel addNewBooking)
        {
            string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = QueryConfig.BookQuerySettings["BookEvent"].ToString();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EventId", addNewBooking.EventId);
                    cmd.Parameters.AddWithValue("@FirstName", addNewBooking.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", addNewBooking.LastName);
                    cmd.Parameters.AddWithValue("@TicketQuantity", addNewBooking.TicketQuantity);
                    cmd.Parameters.AddWithValue("@PhoneNumber", addNewBooking.PhoneNumber);
                    cmd.Parameters.AddWithValue("@RemainSeats", addNewBooking.RemainSeats);
                    cmd.Parameters.AddWithValue("@RegistrationStatus", addNewBooking.RegistrationStatus);
                    cmd.Parameters.AddWithValue("@UserGuid", addNewBooking.UserGuid);
                    cmd.Parameters.AddWithValue("@EventScheduleID", addNewBooking.EventScheduleID);
                    cmd.Parameters.AddWithValue("@Email", addNewBooking.Email);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    if (i > 0)
                        return i;
                    else
                        return 0;
                }
            }
        }
        #endregion

        #endregion
    }
}
