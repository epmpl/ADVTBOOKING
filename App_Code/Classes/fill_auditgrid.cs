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
    /// Summary description for fill_auditgrid
    /// </summary>
    public class fill_auditgrid : connection
    {
        public fill_auditgrid()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet bindgrid(string dateformat, string tilldate, string fromdate, string branch, string adtype, string audittype, string branch2, string abc_cat, string userid, string comp_code)
        {
            SqlConnection con;
            SqlCommand com;
            con = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                com = GetCommand("Bindaudit_grid", ref con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add("@date", SqlDbType.VarChar);
                com.Parameters["@date"].Value = dateformat;

                /*

                com.Parameters.Add("@todate", SqlDbType.VarChar);
                com.Parameters["@todate"].Value = tilldate;

                com.Parameters.Add("@fromdate", SqlDbType.VarChar);
                com.Parameters["@fromdate"].Value = fromdate;*/



                com.Parameters.Add("@adtype", SqlDbType.VarChar);
                com.Parameters["@adtype"].Value = adtype;

                com.Parameters.Add("@branch2", SqlDbType.VarChar);
                if (branch2 != "0" && branch2 != "--Select Branch--" && branch2 != "")
                {
                    com.Parameters["@branch2"].Value = branch2;
                }
                else
                {
                    com.Parameters["@branch2"].Value = System.DBNull.Value;
                }



                com.Parameters.Add("@userid", SqlDbType.VarChar);
                com.Parameters["@userid"].Value = userid;



                com.Parameters.Add("@comp_code", SqlDbType.VarChar);
                com.Parameters["@comp_code"].Value = comp_code;





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