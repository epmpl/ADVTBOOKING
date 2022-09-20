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
using System.Data.OracleClient;
namespace NewAdbooking.classesoracle
{
    /// <summary>
    /// Summary description for clinetintranstion
    /// </summary>
    public class clinetintranstion : orclconnection
    {
        public clinetintranstion()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet clientinsert1(string compcode, string userid, string clientcod)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientupdttrasac", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("pcomp_code", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = compcode;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("puserid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = userid;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("pclientcod", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = clientcod;
                objOraclecommand.Parameters.Add(prm3);



                objOraclecommand.Parameters.Add("p_accounts", OracleType.Cursor);
                objOraclecommand.Parameters["p_accounts"].Direction = ParameterDirection.Output;

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

        public DataSet updatestatusnew(string bookingid, string client, string comp_code)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("clientupdttrasac2", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm4 = new OracleParameter("pciobookid", OracleType.VarChar);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = bookingid;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm7 = new OracleParameter("pclientcod", OracleType.VarChar);
                prm7.Direction = ParameterDirection.Input;
                prm7.Value = client;
                objOraclecommand.Parameters.Add(prm7);


                OracleParameter prm6 = new OracleParameter("pcomp_cod", OracleType.VarChar);
                prm6.Direction = ParameterDirection.Input;
                prm6.Value = comp_code;
                objOraclecommand.Parameters.Add(prm6);

               
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
                objOracleConnection.Close();
            }

        }

    }
}