using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
/// <summary>
/// Summary description for licenseinfo
/// </summary>
/// 
namespace NewAdbooking.Classes
{
    public class licenseinfo : connection
    {
        public licenseinfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet fetchLicenseInfo()
        {
            SqlConnection objSqlConnection;
            SqlCommand objSqlCommand;
            objSqlConnection = GetConnection();
            SqlDataAdapter objSqlDataAdapter;
            DataSet objDataSet = new DataSet();
            try
            {
                objSqlConnection.Open();
                objSqlCommand = GetCommand("fetchLicenseInfo", ref objSqlConnection);
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                objSqlDataAdapter = new SqlDataAdapter();
                objSqlDataAdapter.SelectCommand = objSqlCommand;
                objSqlDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                CloseConnection(ref objSqlConnection);
            }
        }
    }
}