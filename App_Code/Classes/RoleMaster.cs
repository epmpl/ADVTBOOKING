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

/// <summary>
/// Summary description for RoleMaster
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class RoleMaster : connection
    {
        public RoleMaster()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet checkPrevuser(string roleid, string formname)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("wesp_chekRolePermission", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@role_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@role_id"].Value = roleid;

                objSqlCommand.Parameters.Add("@formname1", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname1"].Value = formname;

              


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
        public DataSet insMasterPrev(string prev, string formname, string roleid, string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Wesp_insertRolePermission", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@prev", SqlDbType.VarChar);
                objSqlCommand.Parameters["@prev"].Value = prev;

                objSqlCommand.Parameters.Add("@formname", SqlDbType.VarChar);
                objSqlCommand.Parameters["@formname"].Value = formname;

                objSqlCommand.Parameters.Add("@role_id", SqlDbType.VarChar);
                objSqlCommand.Parameters["@role_id"].Value = roleid;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

               

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
        public DataSet BindRole(string compcode)
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("Rolebind", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlCommand.Parameters.Add("@compcode", SqlDbType.VarChar);
                objSqlCommand.Parameters["@compcode"].Value = compcode;

               
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