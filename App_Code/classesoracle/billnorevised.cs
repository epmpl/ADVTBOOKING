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

/// <summary>
/// Summary description for billnorevised
/// </summary>
namespace NewAdbooking.classesoracle
{
    public class billnorevised:orclconnection
    {
        public billnorevised()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void  insertCioDetail(string billno, string cioid)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("insertCioDetailinTemp", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("billno", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billno;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("cioid", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = cioid;
                objOraclecommand.Parameters.Add(prm2);

                //objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                //objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                // objOraclecommand.ExecuteNonQuery();

                //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;

                objOraclecommand.ExecuteNonQuery();

                //objorclDataAdapter.SelectCommand = objOraclecommand;
                //objorclDataAdapter.Fill(objDataSet);
                //return objDataSet;
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
        public DataSet getBill(string billno, string COMPCODE)
        {
            OracleConnection objOracleConnection;
            OracleCommand objOraclecommand;
            DataSet objDataSet = new DataSet();
            objOracleConnection = GetConnection();
            OracleDataAdapter objorclDataAdapter = new OracleDataAdapter();
            try
            {
                objOracleConnection.Open();
                objOraclecommand = GetCommand("getBillNoBooking", ref objOracleConnection);
                objOraclecommand.CommandType = CommandType.StoredProcedure;

                OracleParameter prm1 = new OracleParameter("billno", OracleType.VarChar);
                prm1.Direction = ParameterDirection.Input;
                prm1.Value = billno;
                objOraclecommand.Parameters.Add(prm1);

                OracleParameter prm2 = new OracleParameter("PCOMPCODE", OracleType.VarChar);
                prm2.Direction = ParameterDirection.Input;
                prm2.Value = COMPCODE;
                objOraclecommand.Parameters.Add(prm2);

                objOraclecommand.Parameters.Add("P_Accounts", OracleType.Cursor);
                objOraclecommand.Parameters["P_Accounts"].Direction = ParameterDirection.Output;
                // objOraclecommand.ExecuteNonQuery();

                //objOraclecommand.Parameters.Add("ht_rep", OracleType.Cursor);
                //objOraclecommand.Parameters["ht_rep"].Direction = ParameterDirection.Output;



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
