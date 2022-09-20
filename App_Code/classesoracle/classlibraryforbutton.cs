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
    /// Summary description for classlibraryforbutton
    /// </summary>
    public class classlibraryforbutton:orclconnection 
    {
        public classlibraryforbutton()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public DataSet getbuttonpermission(string compcode, string userid, string formname)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("Websp_Showpermission.Websp_Showpermission_P", ref objOracleConnection);
               
                objOraclecommand.CommandType = CommandType.StoredProcedure;
                OracleParameter prm1 = new OracleParameter("Formname", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = formname;
                objOraclecommand.Parameters.Add(prm1);
                OracleParameter prm2 = new OracleParameter("Compcode", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = compcode;
                objOraclecommand.Parameters.Add(prm2);
                OracleParameter prm3 = new OracleParameter("Vuserid", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = userid;
                objOraclecommand.Parameters.Add(prm3);
                objOraclecommand.Parameters.Add("p_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts"].Direction = ParameterDirection.Output;
                objOraclecommand.Parameters.Add("p_Accounts1", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts1"].Direction = ParameterDirection.Output;



                objOraclecommand.Parameters.Add("p_Accounts2", OracleType.Cursor);
                objOraclecommand.Parameters["p_Accounts2"].Direction = ParameterDirection.Output;




                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception objException)
            {
                throw (objException);
            }
            finally
            {
                objOracleConnection.Close();
            }
        }
    }
}