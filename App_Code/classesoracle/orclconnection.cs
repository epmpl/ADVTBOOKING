using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{

    /// <summary>
    /// Summary description for orclconnection.
    /// </summary>
    public class orclconnection
    {
        protected static string strConnectionString;
        public orclconnection()
        {
            //strConnectionString = ConfigurationSettings.AppSettings["OracleConnectionString"];
            strConnectionString = ConfigurationSettings.AppSettings["orclconnectionstring"];
        }

        public OracleConnection GetConnection()
        {
            OracleConnection objOracleConnection = new OracleConnection(strConnectionString);
           // find_user("bh01");
            return objOracleConnection;
        }
        public OracleConnection GetConnection_search()
        {
            OracleConnection objOracleConnection = new OracleConnection(ConfigurationSettings.AppSettings["orclconnectionstring_search"].ToString());
            return objOracleConnection;
        }
        public void OpenConnection(ref OracleConnection objConnection)
        {
            if (objConnection.State == ConnectionState.Closed)
                objConnection.Open();

        }
        public void CloseConnection(ref OracleConnection objConnection)
        {
            if (objConnection.State == ConnectionState.Open)
                objConnection.Close();
            objConnection.Dispose();
        }
        public OracleCommand GetCommand(string strOracleStmt, ref OracleConnection objConnection)
        {
            return (new OracleCommand(strOracleStmt, objConnection));
        }
        public void CloseDataReader(ref OracleDataReader objDataReader)
        {
            if (objDataReader != null)
                if (!objDataReader.IsClosed)
                    objDataReader.Close();
        }
        public OracleDataAdapter GetDataAdapter(string strOracleStmt, ref OracleConnection objConnection)
        {
            return (new OracleDataAdapter(strOracleStmt, objConnection));
        }
       /* public void find_user(string p_userid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            OracleConnection objOracleConnection1 = new OracleConnection(strConnectionString);
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection1.Open();
                objOraclecommand = GetCommand("sec_user.set_userid", ref objOracleConnection1);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("p_userid", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = p_userid;
                objOraclecommand.Parameters.Add(prm1);

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

              // return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection1);
            }
        }*/
    }
}