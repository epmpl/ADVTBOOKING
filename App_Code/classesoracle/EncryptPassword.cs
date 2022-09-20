using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{
    /// <summary>
    /// Summary description for EncryptPassword
    /// </summary>
    public class EncryptPassword : orclconnection
    {
        public EncryptPassword()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet encrypt()
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("encrypt_password", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

           


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }


        public DataSet update(string compcode, string userid, string password)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("encrypt_password_update", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

             

                OracleParameter prm6 = new OracleParameter("compcode", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = compcode;
                objOraclecommand.Parameters.Add(prm6);



                OracleParameter prm7 = new OracleParameter("userid", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = userid;
                objOraclecommand.Parameters.Add(prm7);



                OracleParameter prm8 = new OracleParameter("password", OracleType.VarChar);
                prm8.Direction = ParameterDirection.Input;
                prm8.Value = password;
                objOraclecommand.Parameters.Add(prm8);


                objorclDataAdapter.SelectCommand = objOraclecommand;
                objorclDataAdapter.Fill(objDataSet);

                return objDataSet;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                CloseConnection(ref objOracleConnection);
            }
        }





    }
}