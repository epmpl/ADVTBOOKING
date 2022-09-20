using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace NewAdbooking.Classes
{

    /// <summary>
    /// Summary description for reportmisbookingid
    /// </summary>
    public class reportmisbookingid : connection
    {
        public reportmisbookingid()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet bindbookingid(string fromDate, string toDate)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("getMissingId", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@fromdate", SqlDbType.DateTime);
                com.Parameters["@fromdate"].Value = Convert.ToDateTime(fromDate);

                com.Parameters.Add("@todate", SqlDbType.DateTime);
                com.Parameters["@todate"].Value = Convert.ToDateTime(toDate);

                da.SelectCommand = com;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref con);
            }
        }
    }
}