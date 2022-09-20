using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


namespace NewAdbooking.Classes
{// </summary>
    public class matterloghistory : connection
    {
        public matterloghistory()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet MastPrevDisp_user(string compcode, string userid, string userhome, string admin, string retainer, string username)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_ModultPrevDisp_user", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

                objSqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userid"].Value = userid;

                objSqlCommand.Parameters.Add("@userhome", SqlDbType.VarChar);
                objSqlCommand.Parameters["@userhome"].Value = userhome;

                objSqlCommand.Parameters.Add("@admin", SqlDbType.VarChar);
                objSqlCommand.Parameters["@admin"].Value = admin;

                objSqlCommand.Parameters.Add("@retainer_code", SqlDbType.VarChar);
                objSqlCommand.Parameters["@retainer_code"].Value = retainer;

                objSqlCommand.Parameters.Add("@username", SqlDbType.VarChar);
                objSqlCommand.Parameters["@username"].Value = username;

                objSqlCommand.Parameters.Add("@p_extra1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra1"].Value = System.DBNull.Value;

                objSqlCommand.Parameters.Add("@p_extra2", SqlDbType.VarChar);
                objSqlCommand.Parameters["@p_extra2"].Value = System.DBNull.Value;

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

        public DataSet call_data(string tabl, string userid, string frmdt, string todt, string dateformat)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("getmatterlog", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@ptable", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptable"].Value = tabl;

                objSqlCommand.Parameters.Add("@puserid", SqlDbType.VarChar);
                objSqlCommand.Parameters["@puserid"].Value = userid;

                objSqlCommand.Parameters.Add("@pfrmdt", SqlDbType.VarChar);
                objSqlCommand.Parameters["@pfrmdt"].Value = frmdt;

                objSqlCommand.Parameters.Add("@ptdat", SqlDbType.VarChar);
                objSqlCommand.Parameters["@ptdat"].Value = todt;

                

                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }

        }

    }
}