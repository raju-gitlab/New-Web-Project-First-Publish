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
using WP.Repository.IRepository.IEvent;

namespace WP.Repository.Repository.Event
{
    public class CheckEventRepository : ICheckEventRepository
    {
        #region CheckEvent
        public bool  CheckEventAvailability(string EventGuid)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DEV"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    string query = QueryConfig.BookQuerySettings["CheckEvent"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@EventGuid", EventGuid));
                        cmd.CommandType = CommandType.Text;
                        //SqlDataReader rdr = cmd.ExecuteReader();
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error Occured", ex);
            }
        }
        #endregion
    }
}
