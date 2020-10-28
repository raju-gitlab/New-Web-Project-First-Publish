using CommonApplicationFramework.ConfigurationHandling;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Model;
using WP.Model.Event;
using WP.Repository.IRepository;

namespace WP.Repository.Repository
{
    public class EventRepository : IEventRepository
    {
        #region Get

        #region GetEventByEventId
        public List<EventModel> GetActiveEvents(string EventGuid)
        {
            List<EventModel> Getevents = new List<EventModel>();
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["Dev"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetEventById"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@EventGuid", EventGuid));
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Getevents.Add(
                                new EventModel
                                {
                                    EventName = rdr["EventName"].ToString(),
                                    Place = rdr["Place"].ToString(),
                                    FromDate = Convert.ToDateTime(rdr["FromDate"]),
                                    ToDate = Convert.ToDateTime(rdr["ToDate"]),
                                    TotalRegistration = Convert.ToInt32(rdr["TotalRegistration"]),
                                    EventDescription = Convert.ToString(rdr["EventDescription"]),
                                    Year = Convert.ToInt32(rdr["Year"]),
                                    OrganizationName = rdr["OrganizationName"].ToString(),
                                    OrganizationDescription = rdr["OrganizationDescription"].ToString(),
                                    Contact = rdr["Contact"].ToString()
                                });
                        }
                        return Getevents;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetAllEvents
        public List<EventModel> GetEvents()
        {
            try
            {
                List<EventModel> GetAllEvents = new List<EventModel>();
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetAllActiveOpenEvent"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            GetAllEvents.Add(
                                new EventModel
                                {
                                    EventName = rdr["EventName"].ToString(),
                                    Place = rdr["Place"].ToString(),
                                    OrganizationName = rdr["OrganizationName"].ToString(),
                                    Date = rdr["Date"].ToString(),
                                    FromDate = Convert.ToDateTime(rdr["FromDate"]),
                                    ToDate = Convert.ToDateTime(rdr["ToDate"]),
                                    Location = rdr["Location"].ToString(),
                                    Image = rdr["Image"].ToString()
                                });
                        }
                        return GetAllEvents;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetUpcomingEvents
        public List<EventModel> UpcomingEventsList()
        {
            try
            {
                List<EventModel> UpcomingEvents = new List<EventModel>();
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["GetUpcomingEvent"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            UpcomingEvents.Add(
                                               new EventModel
                                               {
                                                   EventName = rdr["EventName"].ToString(),
                                                   Place = rdr["Place"].ToString(),
                                                   OrganizationName = rdr["OrganizationName"].ToString(),
                                                   Date = rdr["Date"].ToString(),
                                                   FromDate = Convert.ToDateTime(rdr["FromDate"]),
                                                   ToDate = Convert.ToDateTime(rdr["ToDate"]),
                                                   Location = rdr["Location"].ToString(),
                                                   Image = rdr["Image"].ToString()
                                               }); 
                        }
                    }
                    return UpcomingEvents;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region GetCancelledEventByUserId
        public List<EventModel> CancelledEvents(string UserId)
        {
            List<EventModel> CancelledEvent = new List<EventModel>();
            string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = QueryConfig.BookQuerySettings["GetCanceldEvent"].ToString();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                    SqlDataReader rdr = cmd.ExecuteReader();
                    CancelledEvent.Add(
                        new EventModel {
                            EventName = rdr["EventName"].ToString(),
                            Place = rdr["Place"].ToString(),
                            Date = rdr["Date"].ToString(),
                            FromDate = Convert.ToDateTime(rdr["FromDate"]),
                            ToDate = Convert.ToDateTime(rdr["ToDate"]),
                            Location = rdr["Location"].ToString(),
                            OrganizationName = rdr["OrganizationName"].ToString(),
                            Registration = new EventRegistrationModel { RegistrationStatus = rdr["RegistrationStatus"].ToString(),TicketId = rdr["TicketId"].ToString(),FirstName = rdr["FirstName"].ToString(),LastName = rdr["LastName"].ToString(), TicketQuantity = Convert.ToInt32(rdr["TicketQuantity"])}
                    });
                }
                return CancelledEvent;
            }
        }
        #endregion

        #endregion
    }
}
