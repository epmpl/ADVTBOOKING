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
    /// Summary description for ROapproval
    /// </summary>
    public class ROapproval : orclconnection
    {
        public ROapproval()
        {
            //
            // TODO: Add constructor logic here
            //
        }
//========================================================================//
        public DataSet getInsertDetail_app_mobile(string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();

            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getInsertDetail_app_mobile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm2 = new OracleParameter("cioid", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cioid;
                objOraclecommand.Parameters.Add(prm2);


                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;

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
//=======================Start===========================================//
        public DataSet addvalue(string agency, string client, string executive, string compcode, string userid, string fromdate, string todate, string dateformat)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getapprovalRo_Mobile", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("agency", OracleType.VarChar, 50);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = agency;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("client", OracleType.VarChar, 50);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = client;
                objOraclecommand.Parameters.Add(prm2);

                OracleParameter prm3 = new OracleParameter("executive", OracleType.VarChar, 50);
                prm3.Direction = ParameterDirection.Input;
                prm3.Value = executive;
                objOraclecommand.Parameters.Add(prm3);

                OracleParameter prm4 = new OracleParameter("compcode", OracleType.VarChar, 50);
                prm4.Direction = ParameterDirection.Input;
                prm4.Value = compcode;
                objOraclecommand.Parameters.Add(prm4);

                OracleParameter prm5 = new OracleParameter("vusername", OracleType.VarChar, 50);
                prm5.Direction = ParameterDirection.Input;
                prm5.Value = userid;
                objOraclecommand.Parameters.Add(prm5);

                OracleParameter prm6 = new OracleParameter("varfromdate", OracleType.VarChar, 50);
                prm6.Direction = ParameterDirection.Input;
                if (dateformat == "dd/mm/yyyy" && fromdate != "" && fromdate != null)
                {
                    string[] arr = fromdate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    fromdate = mm + "/" + dd + "/" + yy;

                }

                if (fromdate == "" || fromdate == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm6.Value = Convert.ToDateTime(fromdate).ToString("dd-MMMM-yyyy");
                }
                objOraclecommand.Parameters.Add(prm6);


                OracleParameter prm7 = new OracleParameter("vartodate", OracleType.VarChar, 50);
                prm7.Direction = ParameterDirection.Input;

                if (dateformat == "dd/mm/yyyy" && todate != "" && todate != null)
                {
                    string[] arr = todate.Split('/');
                    string dd = arr[0];
                    string mm = arr[1];
                    string yy = arr[2];
                    todate = mm + "/" + dd + "/" + yy;

                }

                if (todate == "" || todate == null)
                {
                    prm6.Value = System.DBNull.Value;
                }
                else
                {
                    prm7.Value = Convert.ToDateTime(todate).ToString("dd-MMMM-yyyy");
                }
                
                objOraclecommand.Parameters.Add(prm7);

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
    }
}